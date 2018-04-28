using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Entities
{
    /// <summary>
    /// 汇总信息实体
    /// </summary>
    public class SummaryModel : IViewModel
    {
        /// <summary>
        /// 数量合计
        /// </summary>
        public decimal Quanlity
        {
            get;
            set;
        }

        /// <summary>
        /// 采购金额合计
        /// </summary>
        public decimal PurchaseAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣合计金额
        /// </summary>
        public decimal DiscountAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣后金额合计
        /// </summary>
        public decimal AfterDiscountAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 税额合计
        /// </summary>
        public decimal TaxAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 税后合计金额
        /// </summary>
        public decimal AfterTaxAmount
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 汇总信息实体
    /// </summary>
    public class SaleSummaryModel : IViewModel
    {
        /// <summary>
        /// 数量合计
        /// </summary>
        public decimal Quanlity
        {
            get;
            set;
        }

        /// <summary>
        /// 采购金额合计
        /// </summary>
        public decimal SaleAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣合计金额
        /// </summary>
        public decimal DiscountAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣后金额合计
        /// </summary>
        public decimal AfterDiscountAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 税额合计
        /// </summary>
        public decimal TaxAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 税后合计金额
        /// </summary>
        public decimal AfterTaxAmount
        {
            get;
            set;
        }
    }
}
