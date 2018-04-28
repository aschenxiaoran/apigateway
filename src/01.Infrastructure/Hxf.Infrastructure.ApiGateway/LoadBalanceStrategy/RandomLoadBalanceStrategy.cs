using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery;

namespace Hxf.Infrastructure.ApiGateway.LoadBalanceStrategy {
    public class RandomLoadBalanceStrategy : IServiceLoadBalancer {

        private readonly IServiceDiscoveryProvider _serviceDiscoveryProvider;
        public RandomLoadBalanceStrategy(IServiceDiscoveryProvider serviceDiscoveryProvider)
        {
            _serviceDiscoveryProvider = serviceDiscoveryProvider;
        }

        public async Task<DiscoveryService> Get(IList<DiscoveryService> serviceList) {
            var count = serviceList.Count;
            var index = new Random().Next(0, count - 1);
            return serviceList[index];
        }
    }
}