using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public class HttpSendMessageError : Error
    {
        public HttpSendMessageError(string httpErrorReason):base(httpErrorReason,MiddlewareErrorCode.UnableToCompleteRequestError)
        {
            
        }
    }
}