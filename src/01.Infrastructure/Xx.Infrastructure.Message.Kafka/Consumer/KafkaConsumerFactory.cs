namespace Xx.Infrastructure.Message.Kafka.Consumer
{
    public class KafkaConsumerFactory {

        private static readonly KafkaConsumerFactory _instance = new KafkaConsumerFactory();
        private KafkaConsumerFactory() { }

        public static KafkaConsumerFactory Instance => _instance;

        public IMessageConsumer Create(string groupId) {
            return new KafkaConsumer(new KafkaConsumerConnection(), groupId);
        }
    }
}