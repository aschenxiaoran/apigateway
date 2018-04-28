using Polly.Wrap;

namespace Hxf.Infrastructure.ApiGateway.CircuitBreakers
{
    /// <summary>
    /// 断路器提供者
    /// </summary>
    public interface ICircuitBreakerPolicyProvider {
        PolicyWrap Create();
    }
}