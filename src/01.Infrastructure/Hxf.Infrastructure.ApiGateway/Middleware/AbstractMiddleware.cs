using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Repositories;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.Middleware {
    public abstract class AbstractMiddleware {

        private readonly IHttpDataRepository _httpDataRepository;


        protected AbstractMiddleware(IHttpContextAccessor httpContextAccessor) {
            _httpDataRepository = new HttpDataRepository(httpContextAccessor);
        }

        public abstract Task Invoke(HttpContext context);

        protected async Task SetApiRouteToHttpContext(ApiRoute apiRoute) {
            await _httpDataRepository.Add("ApiRoute", apiRoute);
        }

        protected ApiRoute NetStepApiRoute=>  _httpDataRepository.Get<ApiRoute>("ApiRoute");

        protected HttpRequestMessage NextHttpRequestMessage => _httpDataRepository.Get<HttpRequestMessage>("HttpRequestMessage");

        protected async Task SetHttpRequestMessageToContext(HttpRequestMessage requestMessageData) {
            await _httpDataRepository.Add("HttpRequestMessage", requestMessageData);
        }

        protected bool IsPipelineError => _httpDataRepository.Get<bool>(PipelineErrorConstants.IsPipelineError);

        protected IList<Error> PipelineErrorList => _httpDataRepository.Get<List<Error>>(PipelineErrorConstants.PipelineErrorList);

        public void SetPipelineError(IList<Error> errors) {
            _httpDataRepository.Add(PipelineErrorConstants.IsPipelineError, true);
            _httpDataRepository.Add(PipelineErrorConstants.PipelineErrorList, errors);
        }

       
    }
}