using System;
using Hx.Infrastructure.Consuls;
using Hx.Infrastructure.Zookeepers;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Enum;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery;
using Microsoft.Extensions.Options;

namespace Hxf.Infrastructure.ApiGateway.Tests {
    public class ServiceDiscoveryFactory : IServiceDiscoveryFactory {

       
        public IServiceDiscoveryProvider Create(ServiceDisconveryConfig config) {
            IServiceDiscoveryProvider serviceDiscoveryProvider;
            switch (config.ProviderType) {
                case (int)ServiceDiscoveryProviderTypeEnum.Consul:
                    serviceDiscoveryProvider = new ConsulServiceDiscoveryProvider(config);
                    break;
                case (int)ServiceDiscoveryProviderTypeEnum.Zookeeper:
                    serviceDiscoveryProvider = new ZookeeperServiceDiscoveryProvider(config);
                    break;
                default:
                    throw new InvalidOperationException(nameof(serviceDiscoveryProvider));

            }
            return serviceDiscoveryProvider;
        }

    }
}