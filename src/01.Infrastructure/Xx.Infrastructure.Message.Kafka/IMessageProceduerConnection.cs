using System;
using Confluent.Kafka;

namespace Xx.Infrastructure.Message.Kafka
{
    public interface IMessageProceduerConnection {
        Producer<string,string> Get(int index=0);
        bool Return(Producer<string,string> proceduer);
        TimeSpan FlushTimeSpanSeconds { get; }
    }
}