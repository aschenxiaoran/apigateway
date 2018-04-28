using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums {

    /// <summary>
    /// 现金流类型枚举
    /// </summary>
    public enum CashFlowTypeEnum {

        [Descriptions("资金流入总额")]
        InFlow = 1,

        [Descriptions("资金流出总额")]
        OutFlow = 2,

        [Descriptions("资金流入净额")]
        NetFlow = 3,
    }
}
