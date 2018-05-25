using System;
using Confluent.Kafka;

namespace Xx.Infrastructure.Message.Kafka.Consumer {
    [Serializable]
    public class KafkaMessage {
        public string Topic { get; set; }
        public int Partition { get; set; }
        public Offset Offset { get; set; }
        public string Value { get; set; }
    }
}