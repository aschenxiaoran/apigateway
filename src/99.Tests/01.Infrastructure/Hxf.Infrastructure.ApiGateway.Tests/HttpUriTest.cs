using System;
using Hxf.Infrastructure.ApiGateway.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hxf.Infrastructure.ApiGateway.Tests {
    [TestClass]
    public class HttpUriTest {
        [TestMethod]
        public void test_get_service_key_from_url() {
            var uri = new Uri("http://10.4.69.20:9002/Admin/Menu/GetList");
            var serviceKey = UriHelper.GetServiceName(uri);
            Assert.IsNotNull(uri.Segments);
            Assert.IsTrue(serviceKey == "Admin");
        }
    }
}