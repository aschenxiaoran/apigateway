using System;
using System.Linq;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.RateLimit {
    public class RateLimitMiddleware : AbstractMiddleware {

        private readonly RequestDelegate _nextStep;
        private readonly RateLimitConfig _rateLimitConfig;
        private readonly IRateLimitHandler _rateLimitHandler;
        private const string DefaultClientId = "client";


        public RateLimitMiddleware(RequestDelegate nextStep, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) {
            _nextStep = nextStep;
            _rateLimitConfig = GlobalConfig.RateLimit;
            _rateLimitHandler = new RateLimitHandler(_rateLimitConfig);
        }

        public override async Task Invoke(HttpContext context) {
            if (!_rateLimitConfig.EnableRateLimit) {
                await _nextStep.Invoke(context);
                return;
            }

            var clientIdentity = GetClientRequestIdentity(context, _rateLimitConfig);

        }

        #region private methods

        private ClientRequestIdentity GetClientRequestIdentity(HttpContext context, RateLimitConfig rateLimitConfig) {
            var clientId = GetClientId(context, rateLimitConfig);
            var path = context.Request.Path.ToString().ToLowerInvariant();
            var httpMethod = context.Request.Method.ToLowerInvariant();
            var identity = new ClientRequestIdentity(clientId, path, httpMethod);
            return identity;
        }

        private static string GetClientId(HttpContext context, RateLimitConfig rateLimitConfig) {
            var clientId = DefaultClientId;
            if (context.Request.Headers.Keys.Contains(rateLimitConfig.ClientId)) {
                clientId = context.Request.Headers[rateLimitConfig.ClientId].First();
            }
            return clientId;
        }

        #endregion
    }

    /// <summary>
    /// 客户端请求标识
    /// </summary>
    internal class ClientRequestIdentity {
        public ClientRequestIdentity(string clientId, string path, string httpMethod) {
            ClientId = clientId;
            Path = path;
            HttpMethod = httpMethod;
        }
        public string ClientId { get; private set; }
        public string Path { get; private set; }
        public string HttpMethod { get; private set; }
    }

    public class RateLimitHandler : IRateLimitHandler {
        public RateLimitHandler(RateLimitConfig rateLimit) {

        }
    }

    internal interface IRateLimitHandler {
    }
}
