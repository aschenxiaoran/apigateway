using System;

namespace Hxf.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    [Serializable]
    public class ImportDomainAttribute : Attribute
    {
        public ImportDomainAttribute() { }

        public ImportDomainAttribute(string workBook)
        {
            this.WorkBook = workBook;
        }

        /// <summary>
        /// 工作薄名称(如果设置, 则需要进行对应, 如未设置则默认使用第一个工作薄)
        /// </summary>
        public string WorkBook
        {
            get;
            set;
        }
    }
}
