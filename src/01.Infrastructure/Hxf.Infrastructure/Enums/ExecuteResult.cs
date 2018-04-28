using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums
{
    /// <summary>
    /// 导出任务执行结果
    /// </summary>
    public enum ExecuteResult
    {
        [Descriptions("执行成功")]
        Success = 1,
        
        [Descriptions("执行失败")]
        Failure = 2,
        
        [Descriptions("没有执行")]
        NotExecute = 3,

        [Descriptions("部分执行")]    
        PartialExecute = 4
    }
}
