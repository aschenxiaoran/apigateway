using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums{
    public enum VerifyAmoutEnum{
        [Descriptions("金额等于0")]
        Zero = 0,
        [Descriptions("金额大于0")]
        GreateZero = 1,
    }

    /// <summary>
    /// 核销类型
    /// </summary>
    public enum VerifyTypeEnum{
        [Descriptions("核销应付款")]
        Payment = 1,
        [Descriptions("核销应收款")]
        Receive = 2,
    }
}