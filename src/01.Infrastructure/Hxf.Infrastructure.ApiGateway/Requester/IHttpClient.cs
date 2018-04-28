using System.Net.Http;
using System.Threading.Tasks;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public interface IHttpClient {
        HttpClient HttpClient { get; }

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage);
    }
}