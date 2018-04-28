namespace Hxf.Infrastructure.ApiGateway.Middleware
{
    public abstract class Error {
        protected Error(string message, MiddlewareErrorCode code) {
            Message = message;
            Code = code;
        }

        public string Message { get; private set; }
        public MiddlewareErrorCode Code { get; private set; }

        public override string ToString() {
            return Message;
        }
    }
}