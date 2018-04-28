using System;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public class RequestTimedOutError : Error {
        public RequestTimedOutError(Exception exception)
            : base($"Timeout making http request, exception: {exception.Message}", MiddlewareErrorCode.RequestTimedOutError) {
        }
    }
}