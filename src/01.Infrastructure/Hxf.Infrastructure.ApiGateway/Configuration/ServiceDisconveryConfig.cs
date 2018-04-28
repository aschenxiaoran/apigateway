namespace Hxf.Infrastructure.ApiGateway.Configuration
{
    public class ServiceDisconveryConfig {
        
        public string Host { get; set; }


        public int Port { get; set; }

        public int ProviderType { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public interface IServiceDisconveryConfig
    {
         string Host { get; set; }


         int Port { get; set; }

         int ProviderType { get; set; }

         string UserName { get; set; }

         string Password { get; set; }
    }
}