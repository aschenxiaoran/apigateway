using System.Threading.Tasks;
using Confluent.Kafka;
using Xx.Infrastructure.Message.Kafka.Producers;

namespace Xx.Infrastructure.Message.Kafka
{
    public interface IMessagePublisher
    {
        Task<MessageResult> PublishAsync<TMessage>(string topicName, TMessage messageContent) where TMessage : class, IKafkaMessage, new();
    }
}