using System.ComponentModel;

namespace Hxf.Infrastructure.ApiGateway.Enum
{
    /// <summary>
    /// 服务发现提供者类型
    /// </summary>
    public enum ServiceDiscoveryProviderTypeEnum
    {
        [Description("Consul")]
        Consul=1,
        [Description("Zookeeper")]
        Zookeeper=2
    }
}