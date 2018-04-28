namespace Hxf.Infrastructure
{
    /// <summary>
    /// 单据明细聚合跟接口
    /// </summary>
    public interface IBillItemAggragateRoot : IErpAggragateRoot
    {
        /// <summary>
        /// 所属单据Id
        /// </summary>
        int BelongBillId { get; set; }

        /// <summary>
        /// 所属单据编号
        /// </summary>
        string BelongBillCode { get; set; }
    }

    public abstract class BillItemAggragateRoot : ErpAggragateItemRoot, IBillItemAggragateRoot
    {
        public int BelongBillId { get; set; }
        public string BelongBillCode { get; set; }
    }
}