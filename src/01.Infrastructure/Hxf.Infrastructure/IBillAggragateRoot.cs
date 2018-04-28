using System;

namespace Hxf.Infrastructure
{
    /// <summary>
    /// ���ݻ���ӿ�
    /// </summary>
    public interface IBillAggragateRoot : IErpAggragateRoot,IOperateRecord {

        /// <summary>
        /// ���
        /// </summary>
        string Code { get; set; }

        /// <summary>
        ///��������
        /// </summary>
        int BillType { get; set; }

        /// <summary>
        ///��������
        /// </summary>
        DateTime BillTime { get; set; }

        /// <summary>
        ///�ͻ�
        /// </summary>
        int CustomerId { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        int CustomerType { get; set; }

        /// <summary>
        ///ְԱ
        /// </summary>
        int EmployeeId { get; set; }

        /// <summary>
        ///����
        /// </summary>
        int DepartmentId { get; set; }
         

        /// <summary>
        /// ��ע
        /// </summary>
        string Remark { get; set; }
         
    }
}