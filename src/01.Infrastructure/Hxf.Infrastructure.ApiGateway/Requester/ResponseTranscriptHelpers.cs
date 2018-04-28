using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public static class ResponseTranscriptHelpers {
        public static async Task FromHttpResponseMessage(this HttpResponse resp, HttpResponseMessage msg) {
            resp.SetStatusCode(msg)
                .SetHeaders(msg)
                .SetContentType(msg);

            await resp.SetBodyAsync(msg);
        }

        private static HttpResponse SetStatusCode(this HttpResponse resp, HttpResponseMessage msg)
            => resp.Set(r => r.StatusCode = (int)msg.StatusCode);

        private static HttpResponse SetHeaders(this HttpResponse resp, HttpResponseMessage msg)
            => msg.Headers.Aggregate(resp, (acc, h) => acc.Set(r => r.Headers[h.Key] = new StringValues(h.Value.ToArray())));

        private static async Task<HttpResponse> SetBodyAsync(this HttpResponse resp, HttpResponseMessage msg) {
            using (var stream = await msg.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream)) {
                var content = await reader.ReadToEndAsync();

                return resp.Set(async r => await r.WriteAsync(content));
            }
        }

        private static HttpResponse SetContentType(this HttpResponse resp, HttpResponseMessage msg)
            => resp.Set(r => r.ContentType = msg.Content.Headers.GetValues("Content-Type").Single(), applyIf: msg.Content.Headers.Contains("Content-Type"));

        private static HttpResponse Set(this HttpResponse msg, Action<HttpResponse> config, bool applyIf = true) {
            if (applyIf) {
                config.Invoke(msg);
            }

            return msg;
        }
    }
}