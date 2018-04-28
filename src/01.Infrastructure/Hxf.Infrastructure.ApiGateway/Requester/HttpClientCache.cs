using System.Collections.Concurrent;
using Hxf.Infrastructure.ApiGateway.CircuitBreakers;

namespace Hxf.Infrastructure.ApiGateway.Requester {
    public class HttpClientCache : IHttpClientCache {

        private readonly ConcurrentDictionary<string, ConcurrentQueue<IHttpClient>> _httpClientDictionary;

        public HttpClientCache() {
            _httpClientDictionary = new ConcurrentDictionary<string, ConcurrentQueue<IHttpClient>>();
        }

        public IHttpClient Get(string caheKey, CircuitBreakerConfig circuitBreakerConfig) {
            IHttpClient httpClient;
            if (_httpClientDictionary.TryGetValue(caheKey, out var httpClientQueue)) {
                httpClientQueue.TryDequeue(out httpClient);
                return httpClient ?? CreateHttpClientWapper(circuitBreakerConfig);
            }

            httpClient = CreateHttpClientWapper(circuitBreakerConfig);

            return httpClient;

        }

        public bool Return(string cacheKey, IHttpClient httpClient) {
            bool returnResult;
            if (_httpClientDictionary.TryGetValue(cacheKey, out var httpClientQueue)) {
                httpClientQueue.Enqueue(httpClient);
                returnResult = true;
            }
            else {
                httpClientQueue = new ConcurrentQueue<IHttpClient>();
                httpClientQueue.Enqueue(httpClient);
                returnResult = _httpClientDictionary.TryAdd(cacheKey, httpClientQueue);
            }
            return returnResult;
        }

        private IHttpClient CreateHttpClientWapper(CircuitBreakerConfig circuitBreakerConfig) {

            IHttpClientBuilder httpClientBuilder = new HttpClientBuilder(circuitBreakerConfig);
            var httpClientWrapper = httpClientBuilder.Create(useCookies: true, allowAutoRedirect: true);

            return httpClientWrapper;
        }
    }
}