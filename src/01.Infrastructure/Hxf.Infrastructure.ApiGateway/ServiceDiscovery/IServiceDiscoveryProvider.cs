using System.Collections.Generic;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.Middleware;

namespace Hxf.Infrastructure.ApiGateway.ServiceDiscovery
{
    public interface IServiceDiscoveryProvider
    {
        Task<Response<IList<DiscoveryService>>> Get(string serviceName);
    }
}