using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums {

    /// <summary>
    /// 仓库单据入库类型
    /// </summary>
    public enum StorageInTypeEnum {
        //[Descriptions("")]
        //No=0,
        [Descriptions("成品入库")]
        FinishProduct=1,
        [Descriptions("领用归还")]
        Back = 2,
        [Descriptions("借入")]
        Borrow = 3,
        [Descriptions("其他类型")]
        Other = 99,
    }

    /// <summary>
    /// 出库类型
    /// </summary>
    public enum StorageOutTypeEnum {

        [Descriptions("领料出库")]
        MaterialOut=1,
        [Descriptions("委外加工")]
        OutWork = 2,
        [Descriptions("内部领用")]
        Internal = 3,
        [Descriptions("借出")]
        Out = 4,
        [Descriptions("其他类型")]
        Other = 99,
    }
}
