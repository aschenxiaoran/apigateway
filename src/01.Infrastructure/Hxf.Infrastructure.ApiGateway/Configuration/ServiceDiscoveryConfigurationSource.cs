using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Hxf.Infrastructure.ApiGateway.Configuration
{
    public class ServiceDiscoveryConfigurationSource : FileConfigurationSource {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            FileProvider = FileProvider ?? builder.GetFileProvider();
            return new ServiceDisconveryConfigurationProvider(this);
        }
    }
}
