using Polly.Timeout;

namespace Hxf.Infrastructure.ApiGateway.CircuitBreakers
{
    public class CircuitBreakerConfig {
        public CircuitBreakerConfig() {
            TimeoutStrategy = TimeoutStrategy.Pessimistic;
        }

        public int Timeout { get; set; }

        /// <summary>
        ///Pessimistic-悲观模式
        /// 当委托到达指定时间没有返回时，不继续等待委托完成，并抛超时TimeoutRejectedException异常
        /// Optimistic-乐观模式
        ///  只是触发CancellationTokenSource.Cancel函数，需要等待委托自行终止操作
        /// </summary>
        public TimeoutStrategy TimeoutStrategy { get; set; }
        public int ExceptionsAllowedBeforeBreaking { get; set; }
        public int DurationOfBreak { get; set; }
    }
}