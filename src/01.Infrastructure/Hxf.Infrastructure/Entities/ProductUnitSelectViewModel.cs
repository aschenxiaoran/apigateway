using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Entities
{
    /// <summary>
    /// 产品单位实体
    /// </summary>
    public class ProductUnitSelectViewModel:IViewModel
    {
        /// <summary>
        /// 产品单位Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 是否基本单位
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// 预设采购价
        /// </summary>
        public decimal? DefaultPurchasePrice { get; set; }

        /// <summary>
        /// 最近采购价格
        /// </summary>
        public decimal? LastPurchasePrice { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal? CostPrice { get; set; }

        /// <summary>
        /// 最近销售价格
        /// </summary>
        public decimal? LastSalePrice { get; set; }

        /// <summary>
        /// 一级售价
        /// </summary>
        public decimal? FirstLevelPrice { get; set; }

        /// <summary>
        /// 二级售价
        /// </summary>
        public decimal? SecoundLevelPrice { get; set; }

        /// <summary>
        /// 三级售价
        /// </summary>
        public decimal? ThreeLevelPrice { get; set; }

        /// <summary>
        /// 四级售价
        /// </summary>
        public decimal? FourLevelPrice { get; set; }

        /// <summary>
        /// 五级售价
        /// </summary>
        public decimal? FiveLevelPrice { get; set; }

    }
}
