using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums
{
    public enum PurchaseOrderStatus
    {
        /// <summary>
        /// 已删除
        /// </summary>
        [Descriptions("已作废")]
        Deleted = -1,

        /// <summary>
        /// 草稿
        /// </summary>
        [Descriptions("草稿")]
        Draft = 0,

        /// <summary>
        /// 正常状态
        /// </summary>
        [Descriptions("正常状态")]
        Complete = 1,

        /// <summary>
        /// 部分入库
        /// </summary>
        [Descriptions("部分入库")]
        PartialPurchaseIn = 2,

        /// <summary>
        /// 全部入库
        /// </summary>
        [Descriptions("全部入库")]
        AllPurchaseIn = 3,

        /// <summary>
        /// 部分出库
        /// </summary>
        [Descriptions("部分出库")]
        PartialPurchaseOut = 4,

        /// <summary>
        /// 全部出库
        /// </summary>
        [Descriptions("全部出库")]
        AllPurchaseOut = 5,

        /// <summary>
        /// 已终止
        /// </summary>
        [Descriptions("已终止")]
        Stoped = -2
    }
}
