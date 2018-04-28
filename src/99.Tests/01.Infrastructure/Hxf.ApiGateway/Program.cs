using Hxf.Infrastructure.Logs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Hxf.ApiGateway {
    public class Program {
        public static void Main(string[] args) {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
            Serilogger.SetConfiguration();
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }


    }
}
