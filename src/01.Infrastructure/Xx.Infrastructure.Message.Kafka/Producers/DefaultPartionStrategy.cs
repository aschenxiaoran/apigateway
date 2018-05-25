using System;
using System.Threading.Tasks;

namespace Xx.Infrastructure.Message.Kafka.Producers {
    public class DefaultPartionStrategy : IParitionStrategy {

        private int _defaultPartion = 0;

        public DefaultPartionStrategy() {
        }
        public async Task<int> GetPartition(string topicName, string messageKey,int partitionCount) {
            if (string.IsNullOrWhiteSpace(messageKey)) {
                return _defaultPartion;
            }

            int partitionNum;

            try {
                partitionNum = Int32.Parse(messageKey);
            }
            catch (Exception) {
                partitionNum = messageKey.GetHashCode();
            }

            var parition= Math.Abs(partitionNum % partitionCount);

            return await Task.FromResult(parition);

        }
    }
}