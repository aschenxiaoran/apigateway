using System;

namespace Hxf.Infrastructure
{
    /// <summary>
    /// ���ݾۺϸ�
    /// </summary>
    public abstract class BillAggragateRoot : ErpAggragateRoot, IBillAggragateRoot {

        /// <summary>
        /// ���
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///��������
        /// </summary>
        public int BillType { get; set; }

        /// <summary>
        ///��������
        /// </summary>
        public DateTime BillTime { get; set; }

        /// <summary>
        ///�ջ���
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public int CustomerType { get; set; }

        /// <summary>
        ///������
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        ///����
        /// </summary>
        public int DepartmentId { get; set; }



        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }
                              
    }
}