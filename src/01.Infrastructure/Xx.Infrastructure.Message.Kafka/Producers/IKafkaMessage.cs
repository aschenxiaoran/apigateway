namespace Xx.Infrastructure.Message.Kafka.Producers
{
    public interface IKafkaMessage
    {

        string Key { get; set; }
    }
}