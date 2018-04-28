using System;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.Route.Middleware
{
    public class UnmappableRequestError : Error {
        public UnmappableRequestError(Exception ex) : base($"Error when parsing incoming request, exception: {ex.Message}",MiddlewareErrorCode.UnmappableRequestError) {
        }
    }
}