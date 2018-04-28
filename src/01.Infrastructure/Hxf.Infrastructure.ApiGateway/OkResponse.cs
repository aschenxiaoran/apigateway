using System.Net.Http;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway {
    public class OkResponse<T> : Response<T> {

        public OkResponse(T response):base(response) {
        }
    }
}