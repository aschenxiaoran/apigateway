using System.Collections.Generic;

namespace Hxf.Infrastructure.ApiGateway.Configuration {
    public class ApiRouteConfig {

        public GlobalApiConfig GlobalApiConfig { get; set; }

        public List<ApiRoute> ApiRouteList { get; set; }

        public ApiRouteConfig() {
            GlobalApiConfig=new GlobalApiConfig();
            ApiRouteList = new List<ApiRoute>();
        }
    }

    public class GlobalApiConfig
    {
        public string AdminPath { get; set; }
    }

    public class ApiRoute {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string ServiceName { get; set; }
        public string Version { get; set; }
        public int LoadBalanceType { get; set; }
    }
}
