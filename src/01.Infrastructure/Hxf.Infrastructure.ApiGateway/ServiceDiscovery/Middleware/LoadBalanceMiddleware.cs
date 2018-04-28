using System;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.ServiceDiscovery.Middleware {
    public class LoadBalanceMiddleware : AbstractMiddleware {

        private readonly RequestDelegate _nextStep;
        private readonly IServiceLoadBalancer _serviceLoadBalancer;
        private readonly IServiceDiscoveryProvider _serviceDiscoveryProvider;

        public LoadBalanceMiddleware(RequestDelegate nextStep,
            IServiceDiscoveryProvider serviceDiscoveryProvider,
            IServiceLoadBalancer serviceLoadBalancer,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) {

            _nextStep = nextStep;
            _serviceLoadBalancer = serviceLoadBalancer;
            _serviceDiscoveryProvider = serviceDiscoveryProvider;
        }

        public override async Task Invoke(HttpContext context) {

            var serviceList = await _serviceDiscoveryProvider.Get(NetStepApiRoute.ServiceName);
            if (serviceList.IsError) {
                SetPipelineError(serviceList.Errors);
                return;
            }

            var service = await _serviceLoadBalancer.Get(serviceList.Data);
            var uriBuilder = CreateUriBuilder(service);

            NextHttpRequestMessage.RequestUri = uriBuilder.Uri;

            await _nextStep.Invoke(context);
        }

        private UriBuilder CreateUriBuilder(DiscoveryService service) {
            var uriBuilder = new UriBuilder(NextHttpRequestMessage.RequestUri) {
                Host = service.Host,
                Port = service.Port
            };
            return uriBuilder;
        }
    }
}
