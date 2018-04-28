using System;
using Hxf.Infrastructure.Enums;

namespace Hxf.Infrastructure.Entities {
    /// <summary>
    /// 财务单据基类
    /// </summary>
    public abstract class FinanceBill : SaleAggregateRoot, IFinanceBill {


        /// <summary>
        ///单据编号
        /// </summary>
        public string BillCode { get; set; }

        /// <summary>
        ///单据类型
        /// </summary>
        public int BillType { get; set; }

        /// <summary>
        ///单据日期
        /// </summary>
        public DateTime BillTime { get; set; }

        /// <summary>
        ///单据金额
        /// </summary>
        public decimal BillAmount { get; set; }

        /// <summary>
        ///单据Id
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        ///单据已结算金额
        /// </summary>
        public decimal CheckoutAmount { get; set; }

        /// <summary>
        ///单据未结算金额
        /// </summary>
        public decimal? UnCheckoutAmount { get; set; }
        


        /// <summary>
        /// 所属客户Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 所属客户类型
        /// </summary>
        public int CustomerType { get; set; }

        public int GetBillStatus() {
            var checkoutedAmount = CheckoutAmount;
            var billAmount = BillAmount;
            var billStatus = (int)BillCheckoutStatusEnum.No;
            if (checkoutedAmount == billAmount) {
                billStatus = (int)BillCheckoutStatusEnum.Finish;
            }

            if (checkoutedAmount < billAmount) {
                billStatus = (int)BillCheckoutStatusEnum.Part;
            }


            return billStatus;
        }
    }

    /// <summary>
    /// 财务单据接口
    /// </summary>
    public interface IFinanceBill : ISaleAggregateRoot
    {
        /// <summary>
        ///单据编号
        /// </summary>
        string BillCode { get; set; }

        /// <summary>
        ///单据类型
        /// </summary>
        int BillType { get; set; }

        /// <summary>
        ///单据日期
        /// </summary>
        DateTime BillTime { get; set; }

        /// <summary>
        ///单据金额
        /// </summary>
        decimal BillAmount { get; set; }

        /// <summary>
        ///单据Id
        /// </summary>
        int BillId { get; set; }

        /// <summary>
        ///单据已结算金额
        /// </summary>
        decimal CheckoutAmount { get; set; }

        /// <summary>
        ///单据未结算金额
        /// </summary>
        decimal? UnCheckoutAmount { get; set; }
        

        /// <summary>
        ///显示顺序
        /// </summary>
        int SortIndex { get; set; }


        /// <summary>
        /// 所属客户Id
        /// </summary>
        int CustomerId { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        int CustomerType { get; set; }

        int GetBillStatus();
    }
}