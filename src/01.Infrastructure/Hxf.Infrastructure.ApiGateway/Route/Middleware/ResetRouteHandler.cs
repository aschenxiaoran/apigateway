using System;
using System.Linq;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Helpers;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Hxf.Infrastructure.ApiGateway.Requester;

namespace Hxf.Infrastructure.ApiGateway.Route.Middleware {
    internal class ResetRouteHandler {
        public Response<ApiRoute> GetNextStepRoute(string currentPath, ApiRouteConfig apiRouteConfig) {
            try {
                var requestUri = new Uri(currentPath);
                var serviceName = UriHelper.GetServiceName(requestUri);
                var route = apiRouteConfig.ApiRouteList.FirstOrDefault(a => a.ServiceName.ToLower() == serviceName.ToLower());
                if (route == null) {
                    throw new InvalidRequestRouteException("无效路由请求");
                }
                return new OkResponse<ApiRoute>(route);
            }
            catch (Exception e) {
                return new ErrorResponse<ApiRoute>(new UnmappableRequestError(e));
            }
        }
    }

    internal class InvalidRequestRouteException : Exception {
        public InvalidRequestRouteException(string message) : base(message) {

        }
    }
}