using System;
using Hxf.Infrastructure.ApiGateway.CircuitBreakers;
using Hxf.Infrastructure.ApiGateway.RateLimit;
using Microsoft.Extensions.Configuration;

namespace Hxf.Infrastructure.ApiGateway.Configuration {
    public static class GlobalConfig {

        public static IConfigurationRoot Configuration { get; set; }

        public static ServiceDisconveryConfig ServiceDisconvery
        {
            get
            {
                if (Configuration == null) {
                    throw new NullReferenceException(nameof(Configuration));
                }

                var section = Configuration.GetSection("DiscoveryServiceProvider");
                var consulConfig = section?.Get<ServiceDisconveryConfig>();
                return consulConfig;
            }
        }

        public static CircuitBreakerConfig CircuitBreaker
        {
            get
            {
                if (Configuration == null) {
                    throw new NullReferenceException(nameof(Configuration));
                }

                var section = Configuration.GetSection("CircuitBreaker");
                var consulConfig = section?.Get<CircuitBreakerConfig>();
                return consulConfig;
            }
        }

        public static RateLimitConfig RateLimit
        {
            get
            {
                if (Configuration == null) {
                    throw new NullReferenceException(nameof(Configuration));
                }

                var section = Configuration.GetSection("RateLimit");
                var config = section?.Get<RateLimitConfig>();
                return config;
            }
        }
    }
}
