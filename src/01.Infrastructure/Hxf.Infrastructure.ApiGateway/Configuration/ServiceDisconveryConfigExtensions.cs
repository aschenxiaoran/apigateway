using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Hxf.Infrastructure.ApiGateway.Configuration {
    public static class ServiceDisconveryConfigExtensions {

        public static IConfigurationBuilder AddGatewayFile(this IConfigurationBuilder builder, string path,
            bool optional, bool reloadOnChange) {
            return builder.AddGatewayFile(null, path, optional, reloadOnChange);
        }

        public static IConfigurationBuilder AddGatewayFile(this IConfigurationBuilder builder, IFileProvider fileProvider,
            string path, bool optional, bool reloadOnChange) {

            if (fileProvider == null && Path.IsPathRooted(path)) {
                fileProvider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                path = Path.GetFileName(path);
            }

            var configSource = new ServiceDiscoveryConfigurationSource {
                FileProvider = fileProvider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };

            builder.Add(configSource);
            GlobalConfig.Configuration = builder.Build();
            return builder;
        }
    }
}
