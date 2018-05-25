using System.Threading.Tasks;
using Confluent.Kafka;
using Xx.Infrastructure.Message.Kafka.Producers;

namespace Xx.Infrastructure.Message.Kafka
{
    public interface IMessagePublisher
    {
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="topicName"></param>
        /// <param name="messageContent"></param>
        /// <returns></returns>
        Task<MessageResult> PublishAsync<TMessage>(string topicName, TMessage messageContent) where TMessage : class, IKafkaMessage, new();
    }
}