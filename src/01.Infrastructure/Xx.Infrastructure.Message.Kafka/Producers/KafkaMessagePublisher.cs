using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using log4net;

namespace Xx.Infrastructure.Message.Kafka.Producers {
    public class KafkaMessagePublisher : IMessagePublisher {

        #region private variables

        private Producer<string, string> _producer;
        private readonly IMessageProceduerConnection _kafkaConnection;
        private readonly IParitionStrategy _paritionStrategy;
        private readonly ILog _logger = LogManager.GetLogger(string.Empty,KafkaLogCategory.Error);

        #endregion

        #region ctor

        public KafkaMessagePublisher(IMessageProceduerConnection kafkaConnection, IParitionStrategy paritionStrategy = null) {
            _kafkaConnection = kafkaConnection ?? throw new ArgumentNullException(nameof(kafkaConnection));
            _paritionStrategy = paritionStrategy ?? new DefaultPartionStrategy();
        }

        #endregion

        #region implement message publisher

        public async Task<MessageResult> PublishAsync<TMessage>(string topicName, TMessage messageContent)
            where TMessage : class, IKafkaMessage, new() {
            CheckParameterNullable(topicName, messageContent);

            var messageResult = new MessageResult();

            try {
                var kafkaVal = SerializerHelper.Serialize(messageContent);
                _producer = _kafkaConnection.Get();

                var partition = await GetPartition(topicName, messageContent);
                var message = await _producer.ProduceAsync(topicName, messageContent.Key, kafkaVal, partition);

                _producer.Flush(_kafkaConnection.FlushTimeSpanSeconds);

                if (message.Error.HasError) {
                    messageResult.Errors.Add(message.Error.Code.ToString(), message.Error.Reason);
                }
            }
            catch (Exception exception) {
                messageResult.Errors.Add(exception);
                _logger.Error($"kafka proceduer error topics name:{topicName},error message:{exception.Message}");
            }
            finally {
                
                var isReturned = _kafkaConnection.Return(_producer);
                if (!isReturned) {
                    _producer?.Dispose();
                }
            }

            return messageResult;
        }

        #endregion

        #region private methods
          
        private async Task<int> GetPartition<TMessage>(string topicName, TMessage messageContent)
            where TMessage : class, IKafkaMessage, new() {
            var paritionCount = GetParitionCount(topicName);
            var partition = await _paritionStrategy.GetPartition(topicName, messageContent.Key, paritionCount);
            return partition;
        }

        private int GetParitionCount(string topicName) {
            return GetMataData(topicName).Topics.Select(m => m.Partitions).Count();
        }

        private Metadata GetMataData(string topicName) {
            var metaData = _producer.GetMetadata(false, topicName);
            return metaData;
        }

        private static void CheckParameterNullable<TMessage>(string topicName, TMessage messageContent) {
            if (string.IsNullOrWhiteSpace(topicName)) {
                throw new ArgumentNullException(nameof(topicName));
            }

            if (messageContent == null) {
                throw new ArgumentNullException(nameof(messageContent));
            }
        }

        #endregion
    }
}