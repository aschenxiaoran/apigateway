using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Primitives;

namespace Hxf.Infrastructure.ApiGateway.Requester.Middleware {
    public class InitHttpRequestMiddleware : AbstractMiddleware {

        private readonly RequestDelegate _nextStep;
        private readonly string[] _unsupportedHeaders = { "host" };

        public InitHttpRequestMiddleware(RequestDelegate nextStep, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) {
            _nextStep = nextStep;
        }

        public override async Task Invoke(HttpContext context) {
            var requestMessage = await ConvertToHttpRequestMessage(context.Request);
            if (requestMessage.IsError) {
                SetPipelineError(requestMessage.Errors);
                await Task.FromResult(1);
            }

            await SetHttpRequestMessageToContext(requestMessage.Data);
            await _nextStep.Invoke(context);
        }



        #region private methods

        private async Task<Response<HttpRequestMessage>> ConvertToHttpRequestMessage(HttpRequest httpRequest) {
            try {
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = GetHttpMethod(httpRequest);
                requestMessage.RequestUri = GetRequestUri(httpRequest);
                requestMessage.Content = await GetHttpContent(httpRequest);
                SetHttpRequestMessageHeaders(requestMessage, httpRequest);

                return new OkResponse<HttpRequestMessage>(requestMessage);
            }
            catch (Exception e) {
                return new ErrorResponse<HttpRequestMessage>(new UnConvertToHttpRequestMessageError(e));
            }

        }

        private void SetHttpRequestMessageHeaders(HttpRequestMessage requestMessage, HttpRequest httpRequest) {
            foreach (var header in httpRequest.Headers) {
                if (IsSupportedHeader(header)) {
                    requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
                }
            }
        }

        private bool IsSupportedHeader(KeyValuePair<string, StringValues> header) {
            return !((IList)_unsupportedHeaders).Contains(header.Key.ToLower());
        }

        private async Task<HttpContent> GetHttpContent(HttpRequest httpRequest) {
            if (httpRequest.Body == null) {
                return null;
            }
            var byteContent = await GetByteContent(httpRequest.Body);
            var httpContent = new ByteArrayContent(byteContent);
            SetHttpContentType(httpContent, httpRequest);
            return httpContent;
        }

        private void SetHttpContentType(ByteArrayContent httpContent, HttpRequest httpRequest) {
            httpContent.Headers.TryAddWithoutValidation("Content-Type", new[] { httpRequest.ContentType });
        }

        private async Task<byte[]> GetByteContent(Stream stream) {
            using (stream) {
                using (var memoryStream = new MemoryStream()) {
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }

        }

        private Uri GetRequestUri(HttpRequest httpRequest) {
            return new Uri(httpRequest.GetEncodedUrl());
        }

        private HttpMethod GetHttpMethod(HttpRequest httpRequest) {
            return new HttpMethod(httpRequest.Method);
        }

        #endregion
    }
}
