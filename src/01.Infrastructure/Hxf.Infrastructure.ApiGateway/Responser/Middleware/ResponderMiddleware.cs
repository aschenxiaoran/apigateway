using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Hxf.Infrastructure.ApiGateway.Responser.Middleware {

    public class ResponderMiddleware : AbstractMiddleware {

        #region private variables

        private readonly RequestDelegate _nextStep;
        private readonly IHttpResponseHandler _httpResponseHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpStatusCodeHandler _httpStatusCodeHandler;

        #endregion

        #region  ctor

        public ResponderMiddleware(RequestDelegate nextStep, IHttpStatusCodeHandler httpStatusCodeHandler,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) {
            _nextStep = nextStep;
            _httpContextAccessor = httpContextAccessor;
            _httpStatusCodeHandler = httpStatusCodeHandler;
            _httpResponseHandler = new HttpResponseHandler();
        }

        #endregion

        #region invoke next step

        public override async Task Invoke(HttpContext context) {
            await _nextStep.Invoke(context);

            if (IsPipelineError) {
                var errorList = PipelineErrorList;
                SetErrorToResponse(context, errorList);
            }
            else {
                var response = await GetHttpResponseFromContext();
                await _httpResponseHandler.SetResponseToContext(response, context);
            }
        }

        #endregion

        #region private methods

        private void SetErrorToResponse(HttpContext context, IList<Error> errorList) {
            LogErrorMessage(errorList);
            var statusCode = _httpStatusCodeHandler.GetStatusCode(errorList);
            SetErrorResponseToHttpContext(context, statusCode);
        }

        private static void LogErrorMessage(IList<Error> errorList) {
            foreach (var error in errorList) {
                Log.Error($"code:{error.Code},message:{error.Message}");
            }
        }

        private void SetErrorResponseToHttpContext(HttpContext context, int statusCode)
        {
            context.Response.OnStarting(x => {
                context.Response.StatusCode = statusCode;
                return Task.CompletedTask;
            }, null);
        }

        private async Task<HttpResponseMessage> GetHttpResponseFromContext() {
            if (_httpContextAccessor.HttpContext.Items.TryGetValue("HttpResponseMessage",
                out object value)) {
                var responseMessage = value as HttpResponseMessage;
                return await Task.FromResult(responseMessage);
            }
            throw new NullHttpResponseMessageException("http response message 为空");
        }

        #endregion
    }

    internal class NullHttpResponseMessageException
        : Exception {
        public NullHttpResponseMessageException(string message) : base(message) {

        }
    }
}
