using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums
{
    /// <summary>
    /// 报表维度
    /// </summary>
    public enum BusinessReportDemensionType
    {
        /// <summary>
        /// 简报
        /// </summary>
        [Descriptions("简报")]
        Common = 1,

        /// <summary>
        /// 供应商维度
        /// </summary>
        [Descriptions("供应商维度")]
        BySupplier = 2,

        /// <summary>
        /// 商品维度
        /// </summary>
        [Descriptions("商品维度")]
        ByProduct = 3,

        /// <summary>
        /// 职员维度
        /// </summary>
        [Descriptions("职员维度")]
        ByEmployee = 4,

        /// <summary>
        /// 部门维度
        /// </summary>
        [Descriptions("部门维度")]
        ByDepartment = 5,

        /// <summary>
        /// 地区维度
        /// </summary>
        [Descriptions("地区维度")]
        ByArea = 6,

        /// <summary>
        /// 采购入库明细
        /// </summary>
        [Descriptions("采购入库明细")]
        ByPurchaseInItem = 7,

        /// <summary>
        /// 采购退货明细
        /// </summary>
        [Descriptions("采购退货明细")]
        ByPurchaseReturnItem = 8
    }
}
