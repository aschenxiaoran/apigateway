using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using log4net;
using Xx.Infrastructure.Message.Kafka.Config;

namespace Xx.Infrastructure.Message.Kafka.Producers {
    public class KafkaProducerConnection : IMessageProceduerConnection {

        #region private methods

        private const int MaxQueueSize = 10;
        private int _proceduerCount;
        private Producer<string,string> _producer;
        private static readonly ConcurrentQueue<Producer<string,string>> _producerQueue;
        private readonly ILog _logger = LogManager.GetLogger(string.Empty,KafkaLogCategory.Error);

        #endregion

        #region ctor

        static KafkaProducerConnection() {
            _producerQueue = new ConcurrentQueue<Producer<string,string>>();
        }

        #endregion

        #region implement message connection

        public Producer<string,string> Get(int index = 0)
        {

            if (_producerQueue.TryDequeue(out _producer)) {
                Interlocked.Decrement(ref _proceduerCount);
                return _producer ?? CreateKafkaProducer();
            }

            _producer = CreateKafkaProducer();
            _producer.OnError += OnProducerError;
            _producer.OnLog += OnProducerLog;

            return _producer;
        }

        
        public bool Return(Producer<string,string> proceduer) {
            if (proceduer == null) {
                return false;
            }

            if (Interlocked.Increment(ref _proceduerCount) < MaxQueueSize) {
                _producerQueue.Enqueue(proceduer);
                return true;
            }

            return false;

        }

        public TimeSpan FlushTimeSpanSeconds => TimeSpan.FromSeconds(10);

        #endregion

        #region private methods

        private Producer<string,string> CreateKafkaProducer() {
            var config = GetProducerConfig();
            var valueSerializer = new StringSerializer(Encoding.UTF8);
            var keySerializer=new StringSerializer(Encoding.UTF8);

            return new Producer<string,string>(config, keySerializer, valueSerializer);
        }

        private static Dictionary<string, object> GetProducerConfig() {

            var kafkaConfig = KafkaConfiguration.Setting;
            if (kafkaConfig == null) {
                throw new NullKafkaConfigException(nameof(kafkaConfig));
            }

            var config = new Dictionary<string, object>{
                { "bootstrap.servers", kafkaConfig.Services },
                { "queue.buffering.max.ms", kafkaConfig.QueueBufferingMaxMs },
                { "socket.blocking.max.ms", kafkaConfig.SocketBlockingMaxMs },
                { "enable.auto.commit", kafkaConfig.EnableAutoCommit },
                { "log.connection.close", kafkaConfig.LogConnectionClose },
                { "session.timeout.ms", kafkaConfig.SessionTimeoutMs },//session.timeout.ms 内心跳未到达服务器，服务器认为心跳丢失，会做rebalence
                { "default.topic.config", new Dictionary<string, object>
                    {
                        { "message.timeout.ms", 500 }
                    }
                },
                { "message.send.max.retries", 0 },

            };

            return config;
        }

        private void OnProducerError(object sender, Error error)
        {
            
        }

        private void OnProducerLog(object sender, LogMessage message) {

        }

        #endregion

    }

}