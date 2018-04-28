using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums{
    public enum ProfitTypeEnum{
        [Descriptions("其他收入")]
        OtherIncome=1,

        [Descriptions("费用单")]
        FinanceFee = 2
    }
}