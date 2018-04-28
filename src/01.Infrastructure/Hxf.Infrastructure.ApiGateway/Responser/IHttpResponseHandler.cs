using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.Responser
{
    internal interface IHttpResponseHandler
    {
        Task SetResponseToContext(HttpResponseMessage response, HttpContext context);
    }
}