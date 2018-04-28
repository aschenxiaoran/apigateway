using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums
{
    /// <summary>
    /// 导出文件类型
    /// </summary>
    public enum ExportType
    {
        [Descriptions("导出文件类型为CSV")]
        CSV = 1,

        [Descriptions("导出文件类型为Excel")]
        Excel = 2
    }
}
