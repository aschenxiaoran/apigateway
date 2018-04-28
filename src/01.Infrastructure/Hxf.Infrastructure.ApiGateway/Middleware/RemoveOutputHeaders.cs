using System.Net.Http.Headers;

namespace Hxf.Infrastructure.ApiGateway.Middleware
{
    public class RemoveOutputHeaders : IRemoveOutputHeaders {
        /// <summary>
        /// Some webservers return headers that cannot be forwarded to the client
        /// in a given context such as transfer encoding chunked when ASP.NET is not
        /// returning the response in this manner
        /// </summary>
        private readonly string[] _unsupportedRequestHeaders =
        {
            "Transfer-Encoding"
        };
        public Response Remove(HttpResponseHeaders headers) {
            foreach (var unsupported in _unsupportedRequestHeaders) {
                headers.Remove(unsupported);
            }

            return new OkResponse();
        }
    }

    public interface IRemoveOutputHeaders {
        Response Remove(HttpResponseHeaders headers);
    }

    public class OkResponse : Response {
        public OkResponse() {
        }
    }
}