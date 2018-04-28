using System.Collections.Generic;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Entity;

namespace Hxf.Infrastructure.ApiGateway.ServiceDiscovery
{
    public interface IServiceLoadBalancer
    {
        Task<DiscoveryService> Get(IList<DiscoveryService> serviceList);
    }
}