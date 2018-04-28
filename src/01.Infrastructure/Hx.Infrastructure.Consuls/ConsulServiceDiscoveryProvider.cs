using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Hxf.Infrastructure.ApiGateway;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Hxf.Infrastructure.ApiGateway.Requester;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery;

namespace Hx.Infrastructure.Consuls {
    public class ConsulServiceDiscoveryProvider : IServiceDiscoveryProvider, IDisposable {

        #region private variables

        private readonly ConsulClient _consulClient;
        private const string VersionPrefix = "version-";
        private readonly ConsulConnection _consulConnection;

        #endregion

        #region ctor

        public ConsulServiceDiscoveryProvider(ServiceDisconveryConfig disconveryConfig) {
            _consulConnection = new ConsulConnection(disconveryConfig);
            _consulClient = new ConsulClient(config => {
                config.Address = new Uri($"http://{disconveryConfig.Host}:{disconveryConfig.Port}");
            });
        }

        #endregion

        #region implement service discovery

        public async Task<Response<IList<DiscoveryService>>> Get(string serviceName) {
            try {
                var serviceQueryResult = await _consulClient.Health.Service(serviceName, string.Empty, true)
                    .ConfigureAwait(false);
                var uriServiceList = ConvertToServiceUriList(serviceQueryResult.Response);
                return new OkResponse<IList<DiscoveryService>>(uriServiceList);

            }
            catch (Exception ex) {
                return new ErrorResponse<IList<DiscoveryService>>(new ConsulDiscoveryServiceError(ex));
            }
        }

        public void Dispose() {
            _consulClient?.Dispose();
        }

        #endregion

        #region private methods

        private string GetVersionFromTags(IEnumerable<string> serviceTags) {
            return serviceTags?
                       .FirstOrDefault(m => m.StartsWith(VersionPrefix, StringComparison.Ordinal))
                       ?.Replace(VersionPrefix, string.Empty) ?? string.Empty;
        }

        private DiscoveryService ConvertToUriService(ServiceEntry consulService) {
            var service = new DiscoveryService();
            service.Host = consulService.Service.Address;
            service.Port = consulService.Service.Port;
            service.Id = consulService.Service.ID;
            service.Version = GetVersionFromTags(consulService.Service.Tags);
            return service;
        }

        private IList<DiscoveryService> ConvertToServiceUriList(ServiceEntry[] serviceEntryList) {
            if (serviceEntryList == null || serviceEntryList.Length == 0) {
                throw new NullConsulServiceException($"在consul中无有效的服务可用");
            }

            var serviceList = serviceEntryList.Select(ConvertToUriService);
            return serviceList.ToList();
        }

        #endregion
    }
}