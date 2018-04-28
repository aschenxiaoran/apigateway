using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Hx.CShop.ApiServices.Admins.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

         public static IWebHost BuildWebHost (string[] args) {
            Log.Logger = new LoggerConfiguration ()
                .MinimumLevel.Verbose ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override ("System", LogEventLevel.Warning)
                .MinimumLevel.Override ("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext ()
                .WriteTo.Console ()
                .WriteTo.RollingFile (pathFormat: "logs\\{Date}.txt", restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger ();

            return WebHost.CreateDefaultBuilder (args)
                .UseStartup<Startup> ()
                .ConfigureLogging (builder => {
                    builder.ClearProviders ();
                    builder.AddSerilog ();
                })
                .Build ();
        }
    }
}
