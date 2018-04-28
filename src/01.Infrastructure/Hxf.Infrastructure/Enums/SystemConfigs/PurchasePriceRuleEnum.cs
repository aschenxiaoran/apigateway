using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums.SystemConfigs {
    public enum PurchasePriceRuleEnum {

        [Descriptions("商品预设采购价")]
        Product=1,

        [Descriptions("供应商最近一次采购价")]
        LastPrice = 2,
    }

    public enum SalePriceRuleEnum {

        [Descriptions("商品预设采购价")]
        Product=1,

        [Descriptions("供应商最近一次采购价")]
        LastPrice = 2,
    }
}
