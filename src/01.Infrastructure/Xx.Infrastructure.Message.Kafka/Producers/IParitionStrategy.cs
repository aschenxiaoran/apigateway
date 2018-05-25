using System.Threading.Tasks;

namespace Xx.Infrastructure.Message.Kafka.Producers
{
    public interface IParitionStrategy
    {
        Task<int> GetPartition(string topicName, string messageKey, int partitionCount);
    }
}