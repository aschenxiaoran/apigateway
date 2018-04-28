using System;

namespace Hxf.Infrastructure
{
    /// <summary>
    /// 单据基类接口
    /// </summary>
    public interface IBillAggragateRoot : IErpAggragateRoot,IOperateRecord {

        /// <summary>
        /// 编号
        /// </summary>
        string Code { get; set; }

        /// <summary>
        ///单据类型
        /// </summary>
        int BillType { get; set; }

        /// <summary>
        ///单据日期
        /// </summary>
        DateTime BillTime { get; set; }

        /// <summary>
        ///客户
        /// </summary>
        int CustomerId { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        int CustomerType { get; set; }

        /// <summary>
        ///职员
        /// </summary>
        int EmployeeId { get; set; }

        /// <summary>
        ///部门
        /// </summary>
        int DepartmentId { get; set; }
         

        /// <summary>
        /// 备注
        /// </summary>
        string Remark { get; set; }
         
    }
}