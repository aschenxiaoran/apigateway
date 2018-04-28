using System;

namespace Hxf.Infrastructure
{
    /// <summary>
    /// 单据聚合根
    /// </summary>
    public abstract class BillAggragateRoot : ErpAggragateRoot, IBillAggragateRoot {

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///出库类型
        /// </summary>
        public int BillType { get; set; }

        /// <summary>
        ///出库日期
        /// </summary>
        public DateTime BillTime { get; set; }

        /// <summary>
        ///收货方
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public int CustomerType { get; set; }

        /// <summary>
        ///出库人
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        ///部门
        /// </summary>
        public int DepartmentId { get; set; }



        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
                              
    }
}