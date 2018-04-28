using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums.Admins {
    public enum DataPermissionType {
        [Descriptions("职员供应商权限")]
        Supplier=1,

        [Descriptions("职员客户权限")]
        Customer=2,

        [Descriptions("职员其他往来单位权限")]
        OtherCustomer=3,

        [Descriptions("职员业务数据权限")]
        Employee=4,

        [Descriptions("仓库权限")]
        Inventory=5,
    }
}
