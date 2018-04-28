using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums {
    /// <summary>
    /// 数据导出任务枚举
    /// </summary>
    public enum ExportTaskType {
        [Descriptions("导出所有店铺")]
        ListAllShop = 1,

        [Descriptions("导出部分用户列表用户列表")]
        ListPartialPageShop = 2,

        [Descriptions("导出所有人员信息")]
        ListAllPlatformCompanyUser = 3,

        [Descriptions("导出所有申请单")]
        ListAllApplyAfterSaleOrder = 4
    }
}
