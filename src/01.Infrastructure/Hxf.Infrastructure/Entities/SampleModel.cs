using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Entities {

    /// <summary>
    /// 简单类型
    /// </summary>
    public class SampleModel : IDropDownViewModel {

        /// <summary>
        /// 主键
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// 是否使用
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        /// 所属公司ID
        /// </summary>
        public int CompanyId { get; set; }

        public int Type { get; set; }

        public string TypeDes { get; set; }

        public decimal Quantity { get; set; }
    }

    public class BusinessSampleModel : SampleModel, IViewModel
    {
        /// <summary>
        /// 关联Id
        /// </summary>
        public int AssociativeId { get; set; }

        /// <summary>
        /// 已入库数量
        /// </summary>
        public decimal StorageInQuanlity { get; set; }

        /// <summary>
        /// 剩余入库数量
        /// </summary>
        public decimal RemainStorageInQuanlity { get; set; }

        /// <summary>
        /// 超订入库数量
        /// </summary>
        public decimal ExccessStorageInQuanlity { get; set; }
    }

    public class BillSampleModel : IViewModel {

        public string BillCode { get; set; }

        public int BillType { get; set; }

        public decimal BillAmount { get; set; }

        public decimal CheckoutAmount { get; set; }
    }

    public static class SampleModelExtension {
        public static string FormatValue(this SampleModel sampleModel) {
            var result = $"{sampleModel.Name}({sampleModel.Code})";
            return result;
        }
    }
}
