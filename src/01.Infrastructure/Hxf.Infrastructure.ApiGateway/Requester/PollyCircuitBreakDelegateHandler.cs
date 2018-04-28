using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.CircuitBreakers;

namespace Hxf.Infrastructure.ApiGateway.Requester {
    public class PollyCircuitBreakDelegateHandler : DelegatingHandler {

        private readonly ICircuitBreakerPolicyProvider _circuitBreakerPolicyProvider;

        public PollyCircuitBreakDelegateHandler(ICircuitBreakerPolicyProvider circuitBreakerPolicyProvider) {
            _circuitBreakerPolicyProvider = circuitBreakerPolicyProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var policyWrapper = _circuitBreakerPolicyProvider.Create();
            return await policyWrapper.ExecuteAsync(() => base.SendAsync(request, cancellationToken));
        }
    }
}