using System;
using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Entities.Companys
{

    /// <summary>
    ///系统配置-ViewResponse
    ///</summary>

    public class SystemConfigResponse : IViewResponse {
        public SystemConfigResponse() {
            PurchaseConfig = new PurchaseConfigResponse();
            SaleConfig = new SaleConfigResponse();
            InventoryConfig = new InventoryConfigResponse();
        }

        public bool IsOpenBill { get; set; }

        /// <summary>
        /// 系统是否已启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime EnableTime { get; set; }

        /// <summary>
        /// 采购配置
        /// </summary>
        public PurchaseConfigResponse PurchaseConfig { get; set; }

        /// <summary>
        /// 销售配置
        /// </summary>
        public SaleConfigResponse SaleConfig { get; set; }

        /// <summary>
        /// 库存配置
        /// </summary>
        public InventoryConfigResponse InventoryConfig { get; set; }


    }

    /// <summary>
    /// 采购配置
    /// </summary>
    public class PurchaseConfigResponse : IViewResponse
    {



        /// <summary>
        ///采购单价规则
        /// </summary>
        public int PurchasePriceRule { get; set; }

        /// <summary>
        ///折扣率规则
        /// </summary>
        public bool PurchaseDiscountRateRule { get; set; }

        /// <summary>
        ///税率规则
        /// </summary>
        public bool PurchaseTaxRateRule { get; set; }
    }

    /// <summary>
    /// 销售配置
    /// </summary>
    public class SaleConfigResponse : IViewResponse
    {

        /// <summary>
        ///税率规则
        /// </summary>
        public bool SaleTaxRateRule { get; set; }

        /// <summary>
        ///采购单价规则
        /// </summary>
        public int SalePriceRule { get; set; }
        

        /// <summary>
        ///折扣率规则
        /// </summary>
        public bool SaleDiscountRateRule { get; set; }

        /// <summary>
        ///销售单价低于商品信息最低预设售价
        /// </summary>
        public bool SalePriceAllowLowGoodsPrePrice { get; set; }
    }

    /// <summary>
    /// 库存配置
    /// </summary>
    public class InventoryConfigResponse : IViewResponse
    {

        /// <summary>
        ///允许库存数量为负数
        /// </summary>
        public bool InventoryIsNagative { get; set; }
    }
}