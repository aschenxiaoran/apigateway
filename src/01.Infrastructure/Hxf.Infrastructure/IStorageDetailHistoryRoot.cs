using System;

namespace Hxf.Infrastructure{
    public interface IStorageDetailHistoryRoot : ISaleAggregateRoot{
        /// <summary>
        ///��ƷId
        /// </summary>
        int ProductId { get; set; }

        /// <summary>
        ///��ƷId
        /// </summary>
        int GoodsId { get; set; }

        /// <summary>
        ///�ֿ�Id
        /// </summary>
        int StorageId { get; set; }

        /// <summary>
        ///�ֿ�����
        /// </summary>
        string StorageCode { get; set; }

        /// <summary>
        ///��Ʒ��λId
        /// </summary>
        int? ProductUnitId { get; set; }

        /// <summary>
        ///ԭʼ�������
        /// </summary>
        decimal OrignalQuantity { get; set; }

        /// <summary>
        ///����������
        /// </summary>
        decimal ChangeQuantity { get; set; }

        /// <summary>
        ///�����������
        /// </summary>
        decimal AfterQuantity { get; set; }
        decimal OrignalAmount { get; set; }
        decimal ChangeAmount { get; set; }
        decimal AfterAmount { get; set; }

        /// <summary>
        ///���ݱ��
        /// </summary>
        string BillCode { get; set; }

        /// <summary>
        ///ҵ������(�ڳ����ɹ���⡢���۳���)
        /// </summary>
        int BillType { get; set; }

        /// <summary>
        ///ҵ������
        /// </summary>
        DateTime BillTime { get; set; }
    }
}