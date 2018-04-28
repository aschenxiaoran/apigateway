using System.Collections.Generic;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public class ErrorResponse<T> : Response<T> {
        public ErrorResponse(Error error) : base(new List<Error> { error }) {
        }
    }
}