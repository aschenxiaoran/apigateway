using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.CircuitBreakers;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Polly.CircuitBreaker;
using Polly.Timeout;

namespace Hxf.Infrastructure.ApiGateway.Requester {
    public class HttpClientRequestHandler : IHttpRequestHandler {

        #region private variables

        private readonly IHttpClientCache _httpClientCache;
        private readonly CircuitBreakerConfig _circuitBreakerConfig;

        #endregion

        #region ctor

        public HttpClientRequestHandler(IHttpClientCache httpClientCache, CircuitBreakerConfig circuitBreakerConfig) {
            _httpClientCache = httpClientCache;
            _circuitBreakerConfig = circuitBreakerConfig;
        }
        #endregion

        #region implement http request handler

        public async Task<Response<HttpResponseMessage>> GetResponse(HttpRequestMessage httpRequestMessage) {

            IHttpClient httpClient = null;
            try {
                httpClient = GetHttpClient(httpRequestMessage);
                var response = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);

                if (response.IsSuccessStatusCode) {
                    return new OkResponse<HttpResponseMessage>(response);
                }
                return new ErrorResponse<HttpResponseMessage>(new HttpSendMessageError(response.ReasonPhrase));
            }
            catch (TimeoutRejectedException exception) {
                return
                    new ErrorResponse<HttpResponseMessage>(new RequestTimedOutError(exception));
            }
            catch (BrokenCircuitException exception) {
                return
                    new ErrorResponse<HttpResponseMessage>(new RequestTimedOutError(exception));
            }
            catch (Exception e) {
                return new ErrorResponse<HttpResponseMessage>(new UnExpectHttpSendError(e));
            }
            finally {
                var cacheKey = GetHttpClientCacheKey(httpRequestMessage);
                var resultResult = _httpClientCache.Return(cacheKey, httpClient);
                if (!resultResult) {
                    httpClient?.HttpClient.Dispose();
                }
            }
        }



        #endregion

        #region private methods

        private IHttpClient GetHttpClient(HttpRequestMessage httpRequestMessage) {
            var httpClientCacheKey = GetHttpClientCacheKey(httpRequestMessage);
            var httpClient = _httpClientCache.Get(httpClientCacheKey, _circuitBreakerConfig);
            return httpClient;
        }

        private string GetHttpClientCacheKey(HttpRequestMessage httpRequestMessage) {
            var baseUrl = $"{httpRequestMessage.RequestUri.Scheme}://{httpRequestMessage.RequestUri.Authority}";
            return baseUrl;
        }

        #endregion
    }
}
