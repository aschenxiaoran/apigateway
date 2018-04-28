using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Hx.Infrastructure.Consuls;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Entity;
using Hxf.Infrastructure.ApiGateway.Enum;
using Hxf.Infrastructure.ApiGateway.Helpers;
using Hxf.Infrastructure.ApiGateway.LoadBalanceStrategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hxf.Infrastructure.ApiGateway.Tests {
    [TestClass]
    public class ServiceDiscoveryTest {
        #region private variables

        private readonly LoadBalanceFactory _factory;
        private readonly ServiceDisconveryConfig _disconveryConfig;
        private const string requestUrl = "http://10.4.69.20:9002/Admin/Menu/GetList";

        #endregion

        #region ctor

        public ServiceDiscoveryTest() {
            _disconveryConfig = new ServiceDisconveryConfig {
                ProviderType = (int)ServiceDiscoveryProviderTypeEnum.Consul,
                Host = "127.0.0.1",
                Port = 8500,
            };
            _factory = new LoadBalanceFactory( new ConsulServiceDiscoveryProvider(_disconveryConfig));
        }

        #endregion

        #region test cases

        [TestMethod]
        public async Task Test_Get_Service_From_Load_Balance() {
            var reRoute = GetServiceReRoute();
            var loadBalancer = await _factory.Create(1);
            //var service = await loadBalancer.Get();
            //Assert.IsNotNull(service);
            //Assert.IsNotNull(service.Host);
            //Assert.IsNotNull(service.Version);
        }

        [TestMethod]
        public async Task Test_Get_Service_From_Load_Balance_With_Parrall() {
            var reRoute = GetServiceReRoute();
            int excuteCount = 0;

            try {
                Parallel.Invoke(new ParallelOptions { MaxDegreeOfParallelism = 8 },
                    GetConsulService(reRoute).GetAwaiter().GetResult,
                    GetConsulService3(reRoute).GetAwaiter().GetResult,
                    GetConsulService3(reRoute).GetAwaiter().GetResult,
                    GetConsulService3(reRoute).GetAwaiter().GetResult,
                    GetConsulService3(reRoute).GetAwaiter().GetResult,
                    GetConsulService3(reRoute).GetAwaiter().GetResult,
                    GetConsulService2(reRoute).GetAwaiter().GetResult
                    );
            }
            catch (AggregateException ex) {
                foreach (var single in ex.InnerExceptions) {
                    Console.WriteLine(single.Message);
                }
            }
        }

        [TestMethod]
        public async Task Test_Get_Service_From_Load_Balance_With_Task() {
            var reRoute = GetServiceReRoute();
            const string serviceKey = "Admin";
            var consulClientLazy = new Lazy<ConsulClient>(() => new ConsulClient());
            var consulDic = new ConcurrentDictionary<string, Lazy<ConsulClient>>();
            int excuteCount = 0;
            Parallel.For(0, 3000, new ParallelOptions { MaxDegreeOfParallelism = 8 }, async index => {

                var consulClient = consulDic.GetOrAdd(serviceKey, consulClientLazy).Value;
                var consuleServiceQueryRequest = await consulClient.Agent.Services();
                await consulClient.Health.Service(serviceKey, string.Empty, true);
                var agentServices = consuleServiceQueryRequest.Response.Select(m => m.Value);
            });
            Console.WriteLine(excuteCount);
        }

        #endregion

        #region private methods

        private static ServiceReRoute GetServiceReRoute() {
            var urlRoute = new Uri(requestUrl);
            var serviceKey = UriHelper.GetServiceName(urlRoute);
            var reRoute = new ServiceReRoute { ServiceName = serviceKey };
            return reRoute;
        }

        private async Task GetConsulService(ServiceReRoute reRoute) {
            int excuteCount = 0;
            for (int i = 0; i < 100000; i++) {
                //var loadBalancer = await _factory.Create(reRoute);
                //var service = await loadBalancer.Get();
                //Interlocked.Increment(ref excuteCount);
            }

            Console.WriteLine(excuteCount);
        }
        private async Task GetConsulService2(ServiceReRoute reRoute) {
            int excuteCount = 0;
            for (int i = 0; i < 100000; i++) {
                //var loadBalancer = await _factory.Create(reRoute);
                //var service = await loadBalancer.Get();
                //Interlocked.Increment(ref excuteCount);
            }

            Console.WriteLine(excuteCount);
        }

        private async Task GetConsulService3(ServiceReRoute reRoute) {
            int excuteCount = 0;
            for (int i = 0; i < 100000; i++) {
                //var loadBalancer = await _factory.Create(reRoute);
                //var service = await loadBalancer.Get();
                //Interlocked.Increment(ref excuteCount);
            }

            Console.WriteLine(excuteCount);
        }

        #endregion
    }

    
}
