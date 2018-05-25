using System;

namespace Xx.Infrastructure.Message.Kafka.Consumer {
    internal class NullReceiveHandleException : NullReferenceException {
        public NullReceiveHandleException(string paramName) : base(paramName) {

        }
    }
}