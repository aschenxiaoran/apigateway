using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums {

    /// <summary>
    /// 单据结算状态枚举
    /// </summary>
    public enum BillCheckoutStatusEnum {

        [Descriptions("未结算")]
        No = 0,
        [Descriptions("部分结算")]
        Part = 1,
        [Descriptions("结算完成")]
        Finish = 2,
        [Descriptions("作废")]
        Cancel = -1
    }
}
