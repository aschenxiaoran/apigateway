using System;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.Requester.Middleware
{
    internal class UnConvertToHttpRequestMessageError : Error
    {
        public UnConvertToHttpRequestMessageError(Exception exception) :base(exception.Message,MiddlewareErrorCode.UnmappableRequestError)
        {
            
        }
    }
}