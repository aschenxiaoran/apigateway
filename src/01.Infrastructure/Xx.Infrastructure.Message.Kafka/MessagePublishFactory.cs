using Xx.Infrastructure.Message.Kafka.Producers;

namespace Xx.Infrastructure.Message.Kafka {
    public class MessagePublishFactory : IMessagePublisherFactory {

        private readonly IParitionStrategy _paritionStrategy;
        public MessagePublishFactory(IParitionStrategy paritionStrategy) {
            _paritionStrategy = paritionStrategy;
        }

        public IMessagePublisher Create() {
            return new KafkaMessagePublisher(new KafkaProducerConnection(), _paritionStrategy);
        }
    }

    public interface IMessagePublisherFactory {
        IMessagePublisher Create();
    }
}