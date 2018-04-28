using System;

namespace Hxf.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    [Serializable]
    public class PrintColumnAttribute : Attribute
    {
        private PrintColumnAttribute() { }

        public PrintColumnAttribute(string label, bool isSummaryColumn = false, string summaryFormat = "{0:F4}")
        {
            this.IsSummaryColumn = isSummaryColumn;
            this.Label = label;
            this.SummaryFormat = summaryFormat;
        }

        public PrintColumnAttribute(string label, int columnWidth, bool isSummaryColumn = false, string summaryFormat = "{0:F4}")
        {
            this.Label = label;
            this.ColumnWidth = columnWidth;
            this.IsSummaryColumn = isSummaryColumn;
            this.SummaryFormat = summaryFormat;
        }

        /// <summary>
        /// 列头标签
        /// </summary>
        public string Label
        {
            get;
            set;
        }

        /// <summary>
        /// 列宽
        /// </summary>
        public int ColumnWidth
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示汇总列
        /// </summary>
        public bool IsSummaryColumn
        {
            get;
            set;
        }

        /// <summary>
        /// 汇总列格式化
        /// </summary>
        public string SummaryFormat
        {
            get;
            set;
        }
    }
}
