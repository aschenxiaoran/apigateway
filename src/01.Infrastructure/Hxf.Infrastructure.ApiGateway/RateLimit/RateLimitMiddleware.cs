using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.RateLimit {

    /// <summary>
    /// 限流中间件
    /// </summary>
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
            if (IsWhiteList(clientIdentity, _rateLimitConfig.ClientWhiteList)) {
                await _nextStep.Invoke(context);
                return;
            }

            if (_rateLimitConfig.LimitCount <= 0)
            {
                await _nextStep.Invoke(context);
                return;
            }

        }



        #region private methods

        private static ClientRequestIdentity GetClientRequestIdentity(HttpContext context, RateLimitConfig rateLimitConfig) {
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

        private static bool IsWhiteList(ClientRequestIdentity clientIdentity, IList<string> clientWhiteList) {
            if (clientWhiteList == null || clientWhiteList.Count == 0 || string.IsNullOrWhiteSpace(clientIdentity.ClientId)) {
                return false;
            }
            return clientWhiteList.Contains(clientIdentity.ClientId);
        }

        #endregion
    }
}
