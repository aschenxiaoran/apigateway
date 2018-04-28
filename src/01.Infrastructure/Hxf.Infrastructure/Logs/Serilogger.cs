using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Events;

namespace Hxf.Infrastructure.Logs
{
    public static class Serilogger
    {
        public static void SetConfiguration()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.RollingFile(pathFormat: "logs\\{Date}.txt", restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
        }

    }
}
