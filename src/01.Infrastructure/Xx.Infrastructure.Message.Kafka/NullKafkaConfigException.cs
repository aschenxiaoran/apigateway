using System;

namespace Xx.Infrastructure.Message.Kafka
{
    internal class NullKafkaConfigException : ArgumentNullException {
        public NullKafkaConfigException(string paramName) : base(paramName) {
        }
    }
}