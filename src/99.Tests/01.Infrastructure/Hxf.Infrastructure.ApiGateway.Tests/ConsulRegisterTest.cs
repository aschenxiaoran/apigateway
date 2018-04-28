using System;
using System.Net;
using System.Threading.Tasks;
using Consul;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hxf.Infrastructure.ApiGateway.Tests {
    [TestClass]
    public class ConsulRegisterTest {

        #region private methods

        private const string ServiceId = "Admin";
        private readonly ConsulClient _consulClient;

        #endregion

        #region ctor


        public ConsulRegisterTest() {
            _consulClient = new ConsulClient();
        }

        #endregion

        #region test cases

        [TestMethod]
        public async Task Test_Registe_Service_To_Consul() {

            var service = CreateAgentServiceRegistration(ServiceId);
            await _consulClient.Agent.ServiceDeregister(ServiceId);
            var registerResult = await _consulClient.Agent.ServiceRegister(service);
            var checks = await _consulClient.Health.Checks(ServiceId);
            Assert.IsTrue(registerResult.StatusCode == HttpStatusCode.OK);
            Assert.AreNotEqual((ulong)0, checks.LastIndex);
            Assert.AreNotEqual(0, checks.Response.Length);

        }

        [TestMethod]
        public async Task Test_Get_Service_From_Consul() {

            var service = CreateAgentServiceRegistration(ServiceId);
            await _consulClient.Agent.ServiceDeregister(ServiceId);
            await _consulClient.Agent.ServiceRegister(service);

            var serviceList = await _consulClient.Agent.Services();

            Assert.IsTrue(serviceList.Response.Values.Count > 0);
            Assert.IsTrue(serviceList.Response.ContainsKey(ServiceId));

            await _consulClient.Agent.ServiceDeregister(ServiceId);

        }

        [TestMethod]
        public async Task Test_Deregiste_Service() {
            var service = CreateAgentServiceRegistration(ServiceId);
            await _consulClient.Agent.ServiceRegister(service);
            var deregisteResult = await _consulClient.Agent.ServiceDeregister(ServiceId);
            Assert.IsTrue(deregisteResult.StatusCode == HttpStatusCode.OK);
        }

        #endregion

        #region private methods

        private static AgentServiceRegistration CreateAgentServiceRegistration(string serviceName) {
            var service = new AgentServiceRegistration {
                ID = serviceName,
                Name = serviceName,
                Tags = new[] { "product","version-0001" },
                Port = 9999,
                Address = "127.0.0.1",
                Check = new AgentServiceCheck {
                    HTTP = @"http://127.0.0.1:9999/api/health/status",
                    Timeout = TimeSpan.FromSeconds(3),
                    Interval = TimeSpan.FromSeconds(10)
                }
            };
            return service;
        }


        #endregion
    }


}
