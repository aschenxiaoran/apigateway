using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums{
    /// <summary>
    /// 库存盘点类型
    /// </summary>
    public enum InventoryCheckTypeEnum {

        [Descriptions("商品盘点")]
        Product=1,
        [Descriptions("仓库盘点")]
        Storage = 2,
        
    }
}