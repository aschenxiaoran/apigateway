using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery;

namespace Hx.Infrastructure.Zookeepers
{
    public class ZookeeperServiceDiscoveryProvider : IServiceDiscoveryProvider
    {
        public ZookeeperServiceDiscoveryProvider(ServiceDisconveryConfig config)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IList<DiscoveryService>>> Get(string serviceName)
        {
            throw new NotImplementedException();
        }
    }
}