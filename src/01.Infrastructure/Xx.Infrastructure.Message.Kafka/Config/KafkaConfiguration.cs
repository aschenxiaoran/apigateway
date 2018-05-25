using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Xx.Infrastructure.Message.Kafka.Config {
    public class KafkaConfiguration : ConfigurationSection {

        #region private variables

        private const string KafkaConfigFileName = "kafka.config";
        private const string ServicesKey = "Services";
        private const string QueueBufferingMaxMsKey = "QueueBufferingMaxMs";
        private const string SocketBlockingMaxMsKey = "SocketBlockingMaxMs";
        private const string EnableAutoCommitKey = "EnableAutoCommit";
        private const string LogConnectionCloseKey = "LogConnectionClose";
        private const string SessionTimeoutMsKey = "SessionTimeoutMs";

        private static KafkaConfiguration _setting;
        private static readonly object LockObject = new object();

        #endregion

        #region public properties

        public static KafkaConfiguration Setting
        {
            get
            {
                if (_setting != null) {
                    return _setting;
                }

                lock (LockObject) {
                    //var exeMap = new ExeConfigurationFileMap {
                    //    ExeConfigFilename = KafkaConfigFileName
                    //};
                    //var config = ConfigurationManager.OpenMappedExeConfiguration(exeMap,
                    //    ConfigurationUserLevel.None);

                    //_setting = (KafkaConfiguration)config.GetSection("kafkaConfig");

                    //return _setting;
                    return null;
                }

            }
        }


        //[ConfigurationProperty(ServicesKey, IsRequired = true)]
        public string Services
        {
            get => (string)this[ServicesKey];
            set => this[ServicesKey] = value;
        }


        //[ConfigurationProperty(QueueBufferingMaxMsKey, IsRequired = true)]
        public string QueueBufferingMaxMs
        {
            get => this[QueueBufferingMaxMsKey].ToString();
            set => this[QueueBufferingMaxMsKey] = value;
        }


        //[ConfigurationProperty(SocketBlockingMaxMsKey, IsRequired = true)]
        public string SocketBlockingMaxMs
        {
            get => (string)this[SocketBlockingMaxMsKey];
            set => this[SocketBlockingMaxMsKey] = value;
        }

        //[ConfigurationProperty(EnableAutoCommitKey, IsRequired = true)]
        public string EnableAutoCommit
        {
            get => (string)this[EnableAutoCommitKey];
            set => this[EnableAutoCommitKey] = value;
        }

        //[ConfigurationProperty(LogConnectionCloseKey, IsRequired = true)]
        public string LogConnectionClose
        {
            get => (string)this[LogConnectionCloseKey];
            set => this[LogConnectionCloseKey] = value;
        }

        //[ConfigurationProperty(SessionTimeoutMsKey, IsRequired = true)]
        public string SessionTimeoutMs
        {
            get => (string)this[SessionTimeoutMsKey];
            set => this[SessionTimeoutMsKey] = value;
        }

        #endregion

        public KafkaConfiguration(ConfigurationRoot root, string path) : base(root, path)
        {
        }
    }



}
