using System;
using System.Collections.Generic;
using System.Text;

namespace Hxf.Infrastructure.ApiGateway.RateLimit
{
    public class RateLimitConfig
    {
        public bool EnableRateLimit { get; set; }
        public string ClientId { get; set; }
        public string HttpStatusCode { get; set; }
        public int LimitCount { get; set; }
        public string Period { get; set; }
        public bool DisableRateLimitHeaders { get; set; }
        public IList<string> ClientWhiteList { get; set; }
    }
}
