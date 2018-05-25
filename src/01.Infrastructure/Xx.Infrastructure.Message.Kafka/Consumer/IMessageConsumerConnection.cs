using Confluent.Kafka;

namespace Xx.Infrastructure.Message.Kafka.Consumer
{
    internal interface IMessageConsumerConnection {
        Consumer<string, string> Get(string groupId);
        void Return(Consumer<string, string> consumer);
    }
}