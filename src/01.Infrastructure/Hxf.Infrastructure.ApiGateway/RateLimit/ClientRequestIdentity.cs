namespace Hxf.Infrastructure.ApiGateway.RateLimit
{
    /// <summary>
    /// 客户端请求标识
    /// </summary>
    internal class ClientRequestIdentity {
        public ClientRequestIdentity(string clientId, string path, string httpMethod) {
            ClientId = clientId;
            Path = path;
            HttpMethod = httpMethod;
        }
        public string ClientId { get; private set; }
        public string Path { get; private set; }
        public string HttpMethod { get; private set; }
    }
}