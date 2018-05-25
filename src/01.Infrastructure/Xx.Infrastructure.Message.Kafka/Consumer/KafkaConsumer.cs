using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using log4net;
using Xx.Infrastructure.Message.Kafka.Producers;

namespace Xx.Infrastructure.Message.Kafka.Consumer {
    internal class KafkaConsumer : IMessageConsumer, IDisposable {

        #region private variables

        private readonly string _groupId;
        private Consumer<string, string> _consumer;
        private static readonly object lockObject = new object();
        private readonly IMessageConsumerConnection _connection;
        private readonly ILog _logger = LogManager.GetLogger(string.Empty,KafkaLogCategory.Error);

        #endregion

        #region ctor
        public KafkaConsumer(IMessageConsumerConnection connection, string groupId) {
            _groupId = groupId;
            _connection = connection;
        }

        #endregion

        #region implement message consumer

        public event EventHandler<KafkaMessage> OnReceive;

        public void Subscribe(string topicName) {

            if (string.IsNullOrEmpty(topicName)) {
                throw new ArgumentNullException(nameof(topicName));
            }

            InitCusumer();
            _consumer.Subscribe(topicName);
        }

        public async Task CommitAsync() {
            await _consumer.CommitAsync();
        }

        public void Listen(TimeSpan fromMilliseconds, CancellationToken token) {
            while (true) {
                token.ThrowIfCancellationRequested();
                _consumer.Poll(fromMilliseconds);
            }
        }

        #endregion

        #region implement dispose
        public void Dispose() {
            _consumer?.Dispose();
        }

        #endregion

        #region private methods

        private void InitCusumer() {
            _consumer = _connection.Get(_groupId);
            _consumer.OnMessage += OnMessageHandle;
            _consumer.OnConsumeError += OnConsumerErrorHandle;
            _consumer.OnError += OnErrorHandle;
        }

        private void OnErrorHandle(object sender, Error error) {
            _logger.Error($"kafka consumer error code:{error.Code},reason:{error.Reason}");
            throw new KafkaException(error);
        }

        private void OnConsumerErrorHandle(object sender, Confluent.Kafka.Message message) {
            _logger.Error($"kafka consumer topic:{message.Topic}, partition:{message.Partition},offset:{message.Offset},value:{message.Value}, error code:{message.Error.Code},reason:{message.Error.Reason}");
            throw new KafkaException(message.Error);
        }

        private void OnMessageHandle(object sender, Message<string, string> message) {
            var kafkaMessage = CreateKafkaMessage(message);
            if (OnReceive == null) {
                throw new NullReceiveHandleException(nameof(OnReceive));
            }
            OnReceive?.Invoke(sender, kafkaMessage);
        }

        private static KafkaMessage CreateKafkaMessage(Message<string, string> message) {
            var kafkaMessage = new KafkaMessage {
                Partition = message.Partition,
                Topic = message.Topic,
                Offset = message.Offset,
                Value = message.Value
            };
            return kafkaMessage;
        }

        private async Task TryAction(Action action, Action finallyAction) {
            try {
                await Task.Run(action, new CancellationToken(false))
                    .ContinueWith(task => {
                        if (task.IsFaulted) {
                            throw task.Exception.InnerException;
                        }
                    });
            }
            catch (AggregateException exception) {
                throw;
            }
            catch (Exception exception) {
                //todo log exception
                throw exception;
            }
            finally {
                finallyAction();
            }
        }

        #endregion



    }
}