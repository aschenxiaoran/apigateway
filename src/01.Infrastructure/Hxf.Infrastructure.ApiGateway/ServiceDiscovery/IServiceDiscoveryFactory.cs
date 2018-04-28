using Hxf.Infrastructure.ApiGateway.Configuration;

namespace Hxf.Infrastructure.ApiGateway.ServiceDiscovery
{
    public interface IServiceDiscoveryFactory 
    {
        IServiceDiscoveryProvider Create(ServiceDisconveryConfig config);
    }
}