using System;
using System.Reflection;

namespace Hxf.Infrastructure.Attributes
{
	/// <summary>
	/// FullName： <see cref="T:ECF.EntityPropertyAttribute"/>
	///             Summary ： 数据格式属性
	///             Verssion： 1.0.0.0
	///             DateTime： 2013/4/16 10:56
	///             Author  ： XP-WIN7
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public class EntityPropertyAttribute : Attribute {
		/// <summary>
		/// 属性格式.
		/// 
		/// </summary>
		public PropertyFormat Format { get; set; }

		/// <summary>
		/// 指定是否为数据库字段,默认不需加,只是针对一个实体中非数据库字段的才加.
		/// 
		/// </summary>
		public bool NoDataFeild { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:ECF.EntityPropertyAttribute"/> class.
		/// 
		/// </summary>
		/// <param name="format">The format.</param>
		public EntityPropertyAttribute(PropertyFormat format) {
			this.Format = format;
		}

		/// <summary>
		/// 判断属性是否为数据库字段.
		/// 
		/// </summary>
		/// <param name="pi">属性信息.</param>
		public static bool IsDataField(PropertyInfo pi) {
			object[] customAttributes = pi.GetCustomAttributes(typeof(EntityPropertyAttribute), true);
			if (customAttributes.Length > 0) {
				var propertyAttribute = customAttributes.GetValue(0) as EntityPropertyAttribute;
				if (propertyAttribute != null)
					return propertyAttribute.NoDataFeild;
			}
			return false;
		}
	}
}