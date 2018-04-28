using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums{
    /// <summary>
    /// 配送方式枚举
    /// </summary>
    public enum DeliveryModeEnum{
        [Descriptions("自提")]
        Self = 1,
        [Descriptions("送货")]
        Delivery = 2,
        [Descriptions("快递")]
        Express = 3,

    }
}