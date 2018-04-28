using System.Net.Http;
using System.Threading.Tasks;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public class HttpClientWraper : IHttpClient {

        public HttpClientWraper(HttpClient httpClient) {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage) {
            return HttpClient.SendAsync(requestMessage);
        }
    }
}