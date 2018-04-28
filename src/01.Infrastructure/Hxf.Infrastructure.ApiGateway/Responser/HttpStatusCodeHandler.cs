using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.Responser {
    public class HttpStatusCodeHandler : IHttpStatusCodeHandler {
        public int GetStatusCode(IList<Error> errorList) {
            if (errorList.Any(error =>
            error.Code.Equals(MiddlewareErrorCode.CannotFindServiceError)
            || error.Code.Equals(MiddlewareErrorCode.UnmappableRequestError)
            )) {
                return (int)HttpStatusCode.NotFound;
            }

            return (int)HttpStatusCode.InternalServerError;
        }
    }

    public interface IHttpStatusCodeHandler {
        int GetStatusCode(IList<Error> errorList);
    }
}
