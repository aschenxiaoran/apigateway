using System.Net.Http;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public interface IHttpRequestHandler
    {
        Task<Response<HttpResponseMessage>> GetResponse(HttpRequestMessage httpRequestMessage);
    }
}