using System.Net.Http;
using Hxf.Infrastructure.ApiGateway.CircuitBreakers;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public interface IHttpClientCache
    {
        IHttpClient Get(string caheKey,CircuitBreakerConfig circuitBreakerConfig);
        bool Return(string cacheKey,IHttpClient httpClient);
    }
}