using System;

namespace Xx.Infrastructure.Message.Kafka.Producers
{
    //[Serializable]
    public class KafkaMessage<T> : IKafkaMessage
    {
        public string Key { get; set; }

        public T Value { get; set; }
    }
}