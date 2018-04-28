using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery;

namespace Hxf.Infrastructure.ApiGateway.LoadBalanceStrategy {
    public class DefaultLoadBalanceStrategy : IServiceLoadBalancer
    {

        private readonly IServiceDiscoveryProvider _serviceDiscoveryProvider;
        public DefaultLoadBalanceStrategy(IServiceDiscoveryProvider serviceDiscoveryProvider)
        {
            _serviceDiscoveryProvider = serviceDiscoveryProvider;
        }

        public async Task<DiscoveryService> Get(IList<DiscoveryService> serviceUriList)
        {
            var service = serviceUriList.FirstOrDefault();
            return await Task.FromResult(service);
        }
    }
}