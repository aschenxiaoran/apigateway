using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums
{
    /// <summary>
    /// 时间维度统计时间范围标准
    /// </summary>
    public enum TimeDemensionSummaryType
    {
        /// <summary>
        /// 入库时间
        /// </summary>
        [Descriptions("入库日期")]
        StorageInTime = 1,

        /// <summary>
        /// 退货出库时间
        /// </summary>
        [Descriptions("出库日期")]
        StorageOutTime = 2,

        /// <summary>
        /// 制单时间
        /// </summary>
        [Descriptions("制单日期")]
        CreateTime = 3,

        /// <summary>
        /// 采购日期
        /// </summary>
        [Descriptions("采购日期")]
        PurchaseTime = 4,

        /// <summary>
        /// 退货日期
        /// </summary>
        [Descriptions("退货日期")]
        ReturnTime = 5,

        /// <summary>
        /// 销售时间
        /// </summary>
        [Descriptions("销售时间")]
        SaleTime = 6
    }
}
