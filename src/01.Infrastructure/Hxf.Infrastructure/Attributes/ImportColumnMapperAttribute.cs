using System;
using System.ComponentModel.DataAnnotations;

namespace Hxf.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    [Serializable]
    public class ImportColumnMapperAttribute : Attribute
    {
        internal ImportColumnMapperAttribute() { }

        public ImportColumnMapperAttribute(string mapperName)
        {
            this.MapperName = mapperName;
        }

        public ImportColumnMapperAttribute(string mapperName, object defaultValue)
        {
            this.MapperName = mapperName;
            this.DefaultValue = defaultValue;
        }

        /// <summary>
        /// 导入数据表列头名称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必须映射对象数据列头名称")]
        public string MapperName
        {
            get; set;
        }

        /// <summary>
        /// 数据列默认值(仅能使用系统默认数据类型)
        /// </summary>
        public object DefaultValue
        {
            get; set;
        }

        /// <summary>
        /// 是否为嵌套属性
        /// </summary>
        public bool IsHierarchyNested
        {
            get;
            set;
        }
    }
}
