using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Entities.Finances{
    public enum BillStatusEnum{
        [Descriptions("草稿")]
        Draft = 0,
        [Descriptions("作废")]
        Cancel = -1,
        [Descriptions("已付款")]
        Payed = 1
    }

    public enum FinanceFeeStatus{
        [Descriptions("草稿")]
        Draft = 0,
        [Descriptions("作废")]
        Cancel = -1,
        [Descriptions("已付款")]
        Payed = 1
    }   
}