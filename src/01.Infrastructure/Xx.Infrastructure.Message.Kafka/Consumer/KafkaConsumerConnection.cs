using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Xx.Infrastructure.Message.Kafka.Config;

namespace Xx.Infrastructure.Message.Kafka.Consumer {
    internal class KafkaConsumerConnection : IMessageConsumerConnection {

        #region private variables

        private Consumer<string, string> _consumer;
        private const string DefaultGroupId = "XX.Message.Kafka.Defaut.Group";
        private static readonly ConcurrentQueue<Consumer<string, string>> _consumerQueue;

        #endregion

        #region ctor
        static KafkaConsumerConnection() {
            _consumerQueue = new ConcurrentQueue<Consumer<string, string>>();
        }

        #endregion

        #region public methods

        public Consumer<string, string> Get(string groupId) {
            if (_consumerQueue.TryDequeue(out _consumer)) {
                return _consumer ?? (_consumer = CreateKafkaConsumer(groupId));
            }
            var consumer = CreateKafkaConsumer(groupId);
            return consumer;
        }

        public void Return(Consumer<string, string> consumer) {
            if (consumer == null) {
                return;
            }

            _consumerQueue.Enqueue(consumer);
        }

        #endregion

        #region private methods

        private static Consumer<string, string> CreateKafkaConsumer(string groupId) {
            var consumerConfig = GetKafkaConsumerConfig(groupId);
            var stringDeserializer = new StringDeserializer(Encoding.UTF8);
            var keyDeserializer=new StringDeserializer(Encoding.UTF8);
            var consumer = new Consumer<string, string>(consumerConfig, keyDeserializer, stringDeserializer);
            return consumer;
        }

        private static IEnumerable<KeyValuePair<string, object>> GetKafkaConsumerConfig(string groupId) {

            var kafkaConfig = KafkaConfiguration.Setting;
            if (kafkaConfig == null) {
                throw new NullReferenceException(nameof(kafkaConfig));
            }

            var kafkaGroupId = string.IsNullOrEmpty(groupId) ? DefaultGroupId : groupId;

            var kafkaConsumerConfig = new Dictionary<string, object>
            {
                { "group.id", kafkaGroupId },
                { "enable.auto.commit", false },
                { "auto.commit.interval.ms", 1000 },/* 自动确认offset的时间间隔  */ 
                { "fetch.min.bytes", "1" }, //server发送到消费端的最小数据，若是不满足这个数值则会等待直到满足指定大小。默认为1表示立即接收。  
                { "fetch.wait.max.ms", "1000" }, //若是不满足fetch.min.bytes时，等待消费端请求的最长等待时间  
                { "session.timeout.ms", 30000 },//消息发送的最长等待时间.需大于session.timeout.ms这个时间 
                { "max.poll.records", "100" },//一次从kafka中poll出来的数据条数
                { "auto.commit.interval.ms", 5000 },//自动提交间隔时间
                { "statistics.interval.ms", 60000 },
                { "bootstrap.servers", kafkaConfig.Services },
                { "default.topic.config", new Dictionary<string, object>
                    {
                        { "auto.offset.reset", "smallest" }
                    }
                }
            };
            return kafkaConsumerConfig;
        }

        #endregion
    }
}