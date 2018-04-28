using System;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public class UnExpectHttpSendError : Error
    {
        public UnExpectHttpSendError(Exception exception):base(exception.Message, MiddlewareErrorCode.UnableToCompleteRequestError)
        {
            
        }
    }
}