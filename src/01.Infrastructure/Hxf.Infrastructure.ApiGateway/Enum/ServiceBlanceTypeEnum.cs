using System.ComponentModel;

namespace Hxf.Infrastructure.ApiGateway.Enum
{
    /// <summary>
    /// 服务负载均衡类型
    /// </summary>
    public enum ServiceBlanceTypeEnum {
        [Description("轮询")]
        Poll = 1,
        [Description("随机")]
        Random = 2,
        [Description("加权")]
        Weight = 3,
        [Description("哈希")]
        Hash=4,
        [Description("最少链接")]
        LeastConnect=5
    }
}