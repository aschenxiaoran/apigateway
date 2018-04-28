using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Hxf.Infrastructure.ApiGateway.Responser {

    /// <summary>
    /// http response 处理程序
    /// </summary>
    public class HttpResponseHandler : IHttpResponseHandler {

        #region implement methods

        public async Task SetResponseToContext(HttpResponseMessage response, HttpContext context) {
            RemoveHttpResponseTransferEncoding(response);
            SetHttpContextHeader(response, context);
            await SetHttpContextContent(response, context);
        }

        #endregion

        #region  private methods

        private async Task SetHttpContextContent(HttpResponseMessage response, HttpContext context) {
            var responseContent = await response.Content.ReadAsByteArrayAsync();

            AddContentLengthToHttpContextHeader(context, responseContent.Length);
            SetHttpContextStatusCode(context, response);
            await CopyResponseContentToHttpContextContent(responseContent, context, response.StatusCode);
        }

        private void AddContentLengthToHttpContextHeader(HttpContext context, int responseContentLength) {
            if (!context.Response.Headers.ContainsKey("Content-Length")) {
                context.Response.Headers.Add("Content-Length", new StringValues(responseContentLength.ToString()));
            }
        }

        private void SetHttpContextStatusCode(HttpContext context, HttpResponseMessage response) {
            context.Response.OnStarting(state => {
                var httpContext = (HttpContext)state;
                httpContext.Response.StatusCode = (int)response.StatusCode;
                return Task.CompletedTask;
            }, context);
        }

        private async Task CopyResponseContentToHttpContextContent(byte[] responseContent, HttpContext context, HttpStatusCode responseStatus) {
            using (Stream stream = new MemoryStream(responseContent)) {
                if (responseStatus != HttpStatusCode.NotModified) {
                    await stream.CopyToAsync(context.Response.Body);
                }
            }
        }

        private void RemoveHttpResponseTransferEncoding(HttpResponseMessage response) {
            response.Headers.Remove("Transfer-Encoding");
        }

        private void SetHttpContextHeader(HttpResponseMessage response, HttpContext context) {
            AddHttpHeaderFromHttpResponseMessageHeader(response, context);
            AddHttpHeaderFromHttpResponseMessageContentHeader(response, context);
        }

        private static void AddHttpHeaderFromHttpResponseMessageHeader(HttpResponseMessage response, HttpContext context) {
            foreach (var httpResponseHeader in response.Headers) {
                if (!context.Response.Headers.ContainsKey(httpResponseHeader.Key)) {
                    context.Response.Headers.Add(httpResponseHeader.Key, new StringValues(httpResponseHeader.Value.ToArray()));
                }
            }
        }

        private static void AddHttpHeaderFromHttpResponseMessageContentHeader(HttpResponseMessage response, HttpContext context) {
            foreach (var httpContentHeader in response.Content.Headers) {
                if (!context.Response.Headers.ContainsKey(httpContentHeader.Key)) {
                    context.Response.Headers.Add(httpContentHeader.Key, new StringValues(httpContentHeader.Value.ToArray()));
                }
            }
        }


        #endregion

    }
}