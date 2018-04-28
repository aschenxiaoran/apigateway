using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Hxf.Infrastructure.ApiGateway.Route.Middleware {
    public class ResetRouteMiddleware : AbstractMiddleware {

        private readonly RequestDelegate _nextStep;
        private readonly ResetRouteHandler _resetRouteHandler;
        private readonly IOptions<ApiRouteConfig> _routeOption;

        public ResetRouteMiddleware(RequestDelegate nextStep, IHttpContextAccessor httpContextAccessor, IOptions<ApiRouteConfig> routeConfig
            ) : base(httpContextAccessor) {
            _nextStep = nextStep;
            _routeOption = routeConfig;
            _resetRouteHandler = new ResetRouteHandler();
        }

        public override async Task Invoke(HttpContext context) {
            var currentPath = context.Request.GetEncodedUrl();
            var nextStepRoute = _resetRouteHandler.GetNextStepRoute(currentPath, _routeOption.Value);
            if (nextStepRoute.IsError) {
                SetPipelineError(nextStepRoute.Errors);

            }
            else {
                await SetApiRouteToHttpContext(nextStepRoute.Data);
                await _nextStep.Invoke(context);
            }


        }


    }
}
