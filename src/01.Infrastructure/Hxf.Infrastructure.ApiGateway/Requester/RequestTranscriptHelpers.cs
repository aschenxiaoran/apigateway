﻿using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.Requester
{
    public static class RequestTranscriptHelpers {
        public static HttpRequestMessage ToHttpRequestMessage(this HttpRequest httpRequest)
            => new HttpRequestMessage()
                .SetMethod(httpRequest)
                .SetAbsoluteUri(httpRequest)
                .SetHeaders(httpRequest)
                .SetContent(httpRequest)
                .SetContentType(httpRequest);

        private static HttpRequestMessage SetAbsoluteUri(this HttpRequestMessage msg, HttpRequest req)
            => msg.Set(m => m.RequestUri = new UriBuilder {
                Scheme = req.Scheme,
                Host = req.Host.Host,
                Port = req.Host.Port.Value,
                Path = req.PathBase.Add(req.Path),
                Query = req.QueryString.ToString()
            }.Uri);

        private static HttpRequestMessage SetMethod(this HttpRequestMessage msg, HttpRequest req)
            => msg.Set(m => m.Method = new HttpMethod(req.Method));

        private static HttpRequestMessage SetHeaders(this HttpRequestMessage msg, HttpRequest req)
            => req.Headers.Aggregate(msg, (acc, h) => acc.Set(m => m.Headers.TryAddWithoutValidation(h.Key, h.Value.AsEnumerable())));

        private static HttpRequestMessage SetContent(this HttpRequestMessage msg, HttpRequest req)
            => msg.Set(m => m.Content = new StreamContent(req.Body));

        private static HttpRequestMessage SetContentType(this HttpRequestMessage msg, HttpRequest req)
            => msg.Set(m => m.Content.Headers.Add("Content-Type", req.ContentType), applyIf: req.Headers.ContainsKey("Content-Type"));

        private static HttpRequestMessage Set(this HttpRequestMessage msg, Action<HttpRequestMessage> config, bool applyIf = true) {
            if (applyIf) {
                config.Invoke(msg);
            }

            return msg;
        }
    }
}