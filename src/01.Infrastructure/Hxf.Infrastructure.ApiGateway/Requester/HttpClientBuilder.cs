using System;
using System.Collections.Generic;
using System.Net.Http;
using Hxf.Infrastructure.ApiGateway.CircuitBreakers;

namespace Hxf.Infrastructure.ApiGateway.Requester {
    internal class HttpClientBuilder : IHttpClientBuilder {

        private readonly CircuitBreakerConfig _circuitBreakerConfig;
        private readonly IDictionary<int, Func<DelegatingHandler>> _handlerList = new Dictionary<int, Func<DelegatingHandler>>();

        public HttpClientBuilder(CircuitBreakerConfig circuitBreakerConfig) {
            _circuitBreakerConfig = circuitBreakerConfig;
        }

        public IHttpClient Create(bool useCookies, bool allowAutoRedirect) {

            var httpClientHander = new HttpClientHandler {
                UseCookies = useCookies,
                AllowAutoRedirect = allowAutoRedirect,
            };

            var httpMessageHandler = CreateHttpMessageHandler(httpClientHander);
            var httpClient = new HttpClient(httpMessageHandler);
            return new HttpClientWraper(httpClient);
        }

        private HttpMessageHandler CreateHttpMessageHandler(HttpMessageHandler httpMessageHandler) {
            var circuitBreakerPolicyProvider = new CircuitBreakerPolicyProvier(_circuitBreakerConfig);
            var circuitBreakDelegateHandler =new PollyCircuitBreakDelegateHandler(circuitBreakerPolicyProvider) {
                    InnerHandler = httpMessageHandler
                };
            return circuitBreakDelegateHandler;
        }
    }
}