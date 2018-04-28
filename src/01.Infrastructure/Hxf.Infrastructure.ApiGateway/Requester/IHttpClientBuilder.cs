namespace Hxf.Infrastructure.ApiGateway.Requester
{
    internal interface IHttpClientBuilder
    {
        IHttpClient Create(bool useCookies, bool allowAutoRedirect);
    }
}