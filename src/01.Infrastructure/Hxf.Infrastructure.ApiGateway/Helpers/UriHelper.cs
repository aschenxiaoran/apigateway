using System;

namespace Hxf.Infrastructure.ApiGateway.Helpers
{
    public class UriHelper {
        public static string GetServiceName(Uri uri) {
            var uriSegmentList = uri.Segments;
            if (uriSegmentList.Length < 2) {
                throw new InvalidOperationException(nameof(uriSegmentList));
            }
            var serviceKey = uriSegmentList[1].Replace("/", "");
            if (string.IsNullOrWhiteSpace(serviceKey)) {
                throw new ArgumentNullException(nameof(serviceKey));
            }
            return serviceKey;
        }
    }
}