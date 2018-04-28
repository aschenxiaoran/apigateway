using System;
using System.Reflection;

namespace Hxf.Infrastructure.Attributes
{
	/// <summary>
	/// FullName�� <see cref="T:ECF.EntityPropertyAttribute"/>
	///             Summary �� ���ݸ�ʽ����
	///             Verssion�� 1.0.0.0
	///             DateTime�� 2013/4/16 10:56
	///             Author  �� XP-WIN7
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public class EntityPropertyAttribute : Attribute {
		/// <summary>
		/// ���Ը�ʽ.
		/// 
		/// </summary>
		public PropertyFormat Format { get; set; }

		/// <summary>
		/// ָ���Ƿ�Ϊ���ݿ��ֶ�,Ĭ�ϲ����,ֻ�����һ��ʵ���з����ݿ��ֶεĲż�.
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
		/// �ж������Ƿ�Ϊ���ݿ��ֶ�.
		/// 
		/// </summary>
		/// <param name="pi">������Ϣ.</param>
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