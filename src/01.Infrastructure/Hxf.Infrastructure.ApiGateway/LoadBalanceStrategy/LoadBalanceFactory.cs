using System;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.Enum;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery;

namespace Hxf.Infrastructure.ApiGateway.LoadBalanceStrategy {
    public class LoadBalanceFactory : ILoadBalanceFactory {

        private readonly IServiceDiscoveryProvider _serviceDiscoveryProvider;

        public LoadBalanceFactory(IServiceDiscoveryProvider serviceDiscoveryProvider) {
            _serviceDiscoveryProvider = serviceDiscoveryProvider;
        }

        public async Task<IServiceLoadBalancer> Create(int loadBlanceType) {
            var serviceProvider = _serviceDiscoveryProvider;
            switch (loadBlanceType) {
                case (int)ServiceBlanceTypeEnum.Random:
                    return new RandomLoadBalanceStrategy(_serviceDiscoveryProvider);
                default:
                    return new DefaultLoadBalanceStrategy(_serviceDiscoveryProvider);
            }
        }
    }

    public interface ILoadBalanceFactory {
        Task<IServiceLoadBalancer> Create(int loadBlanceType);
    }
}