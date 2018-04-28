using System;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hx.Infrastructure.Consuls
{
    public class ConsulDiscoveryServiceError : Error
    {
        public ConsulDiscoveryServiceError(Exception exception):base(exception.Message,MiddlewareErrorCode.CannotFindServiceError)
        {
            
        }
    }
}