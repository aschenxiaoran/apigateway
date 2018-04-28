using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums {
    public enum BillTypeEnum {
        [Descriptions("采购订单")]
        Purchase = 1,

        [Descriptions("采购入库单")]
        PurchaseIn = 2,

        [Descriptions("采购退货单")]
        PurchaseReturn = 3,

        [Descriptions("销售订单")]
        Sales = 4,

        [Descriptions("销售出库单")]
        SalesOut = 5,

        [Descriptions("销售退货单")]
        SalesReturn = 6,

        [Descriptions("往来客户付款单")]
        SupplierFinance = 7,

        [Descriptions("期初应付款")]
        ShouldPay = 8,

        [Descriptions("期初应收款")]
        ShouldReceive = 9
    }

    /// <summary>
    /// 核销应付款单据类型
    /// </summary>
    public enum VerfyPaymentBillTypeEnum {
        
        [Descriptions("付款单")]
        Payment = 2,

        [Descriptions("采购退货单")]
        PurchaseReturn = 3,

        [Descriptions("销售出库单")]
        SalesOut = 5,
        
        [Descriptions("期初应付款")]
        ShouldPay = 8,

        [Descriptions("期初应收款")]
        ShouldReceive = 9,

        [Descriptions("其他收入单")]
        OtherIncome = 10,
    }

    /// <summary>
    /// 核销应收款单据类型
    /// </summary>
    public enum VerfyReceiveBillTypeEnum {

        [Descriptions("收款单")]
        Receive = 1,

        [Descriptions("销售退货单")]
        SalesReturn = 6,

        [Descriptions("期初应付款")]
        ShouldPay = 8,

        [Descriptions("期初应收款")]
        ShouldReceive = 9,

        [Descriptions("费用单")]
        FinanceFee = 11,

        [Descriptions("采购入库单")]
        PurchaseIn = 17,
               
    }

    public enum ReceiveBillTypeEnum {


        [Descriptions("采购退货单")]
        PurchaseReturn = 1,

        [Descriptions("销售订单")]
        Sales = 2,

        [Descriptions("销售出库单")]
        SalesOut = 3,

        [Descriptions("其他收入单")]
        SalesReturn = 4,

        [Descriptions("应收款增加")]
        ShouldReceiveIncrease = 5,


        [Descriptions("期初应收款")]
        ShouldReceiveInit = 6
    }

    public enum TotalBillTypeEnum {
        [CodePrefix("SKD")]
        [Descriptions("收款单")]
        Receive = 1,

        [CodePrefix("FKD")]
        [Descriptions("付款单")]
        Payment = 2,

        [CodePrefix("CGTHD")]
        [Descriptions("采购退货单")]
        PurchaseReturn = 3,

        [CodePrefix("XSDD")]
        [Descriptions("销售订单")]
        Sales = 4,

        [CodePrefix("XSCKD")]
        [Descriptions("销售出库单")]
        SalesOut = 5,

        [CodePrefix("XSTHD")]
        [Descriptions("销售退货单")]
        SalesReturn = 6,


        [CodePrefix("QCYFK")]
        [Descriptions("期初应付款")]
        ShouldPay = 8,

        [CodePrefix("QCYSK")]
        [Descriptions("期初应收款")]
        ShouldReceive = 9,

        [CodePrefix("QTSRD")]
        [Descriptions("其他收入单")]
        OtherIncome = 10,

        [CodePrefix("FYD")]
        [Descriptions("费用单")]
        FinanceFee = 11,

        [CodePrefix("ZJZJD")]
        [Descriptions("资金增加")]
        FundsIncrease = 12,

        [CodePrefix("ZJJSD")]
        [Descriptions("资金减少")]
        FundsReducec = 13,

        [CodePrefix("NBZZD")]
        [Descriptions("内部转账")]
        Transfer = 14,

        [CodePrefix("QTRKD")]
        [Descriptions("其他入库单")]
        StorageIn = 15,

        [CodePrefix("QTCKD")]
        [Descriptions("其他出库单")]
        StorageOut = 16,

        [CodePrefix("CGRKD")]
        [Descriptions("采购入库单")]
        PurchaseIn = 17,

        [CodePrefix("HXD")]
        [Descriptions("核销单")]
        Verify = 18,

        [CodePrefix("CBTJD")]
        [Descriptions("库存成本调价单")]
        InventoryCost = 19,

        [CodePrefix("PZD")]
        [Descriptions("盘整单")]
        InventoryCheck = 20,

        [CodePrefix("NBDBD")]
        [Descriptions("内部调拨单")]
        InventoryTransfer = 21,

        [CodePrefix("PrintConfig")]
        [Descriptions("内部调拨单")]
        PrintConfig = 22,
    }
}