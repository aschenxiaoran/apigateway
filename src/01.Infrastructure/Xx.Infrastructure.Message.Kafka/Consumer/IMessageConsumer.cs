using System;
using System.Threading;
using System.Threading.Tasks;

namespace Xx.Infrastructure.Message.Kafka.Consumer {
    public interface IMessageConsumer {
        void Subscribe(string topicName);
        event EventHandler<KafkaMessage> OnReceive;
        void Listen(TimeSpan fromMilliseconds, CancellationToken token);
        Task CommitAsync();
    }
}