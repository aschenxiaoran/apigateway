using System;
using System.Net.Http;
using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;
using Polly.Wrap;

namespace Hxf.Infrastructure.ApiGateway.CircuitBreakers
{
    public class CircuitBreakerPolicyProvier : ICircuitBreakerPolicyProvider {
        private readonly CircuitBreakerConfig _config;

        public CircuitBreakerPolicyProvier(CircuitBreakerConfig config) {
            _config = config;
        }

        public PolicyWrap Create() {
            var timeoutPolicy = CreateTimeoutPolicy();
            var circuitBreakerPolicy = CreateCircuitBreakerPolicy();

            var policyWrap = Policy.WrapAsync(timeoutPolicy, circuitBreakerPolicy);
            return policyWrap;
        }

        private TimeoutPolicy CreateTimeoutPolicy() {
            return Policy.TimeoutAsync(TimeSpan.FromSeconds(_config.Timeout), _config.TimeoutStrategy);
        }

        private CircuitBreakerPolicy CreateCircuitBreakerPolicy() {
            var durationOfBreak = TimeSpan.FromSeconds(_config.DurationOfBreak);
            var exceptionsAllowedBeforeBreaking = _config.ExceptionsAllowedBeforeBreaking;
            return Policy
                .Handle<HttpRequestException>()
                .Or<TimeoutRejectedException>()
                .Or<TimeoutException>()
                .CircuitBreakerAsync(
                    exceptionsAllowedBeforeBreaking: exceptionsAllowedBeforeBreaking,
                    durationOfBreak: durationOfBreak,
                    onBreak: (ex, breaker) => {

                    },
                    onReset: () => {

                    },
                    onHalfOpen: () => {

                    }
                );
        }

    }
}