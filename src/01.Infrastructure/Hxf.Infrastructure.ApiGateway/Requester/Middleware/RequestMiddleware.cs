using System.Net.Http;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Hxf.Infrastructure.ApiGateway.Repositories;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.Requester.Middleware {

    /// <summary>
    /// 处理请求管道
    /// </summary>
    public class RequestMiddleware : AbstractMiddleware {

        #region private variables

        private readonly RequestDelegate _nextStep;
        private readonly IHttpRequestHandler _httpRequestHandler;
        private readonly IHttpDataRepository _httpDataRepository;

        #endregion

        #region ctor

        public RequestMiddleware(RequestDelegate nextStep, IHttpClientCache httpClientCache,
            IHttpContextAccessor httpContextAccessor):base(httpContextAccessor) {
            _nextStep = nextStep;
            _httpRequestHandler = new HttpClientRequestHandler(httpClientCache, GlobalConfig.CircuitBreaker);
            _httpDataRepository = new HttpDataRepository(httpContextAccessor);
        }

        #endregion

        #region implement invoke 

        public override async Task Invoke(HttpContext context) {

            var response = await _httpRequestHandler.GetResponse(NextHttpRequestMessage).ConfigureAwait(false);
            if (response.IsError) {
                SetPipelineError(response.Errors);
                await Task.FromResult(-1);
            }

            await SetHttpResponseMessageToHttpContext(response.Data);
        }

        #endregion

        #region private methods

        private async Task SetHttpResponseMessageToHttpContext(HttpResponseMessage message) {
            await _httpDataRepository.Add("HttpResponseMessage", message);
        }

        #endregion

    }
}
