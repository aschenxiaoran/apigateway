using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Hxf.Infrastructure.Attributes;
using Hxf.Infrastructure.Extensions;

namespace Hxf.Infrastructure.Utilities {


	public class EnumUtility {

        public static IEnumerable<EnumEntity> GetEnumItem<T>() {
            Type type = typeof(T);
            if (!type.IsEnum) {
                throw new ArgumentException("传入的参数必须是枚举类型！", "EnumType");
            }
            foreach (Enum enumValue in Enum.GetValues(type)) {
                yield return new EnumEntity {
                    Value = Convert.ToInt32(enumValue),
                    Name = enumValue.GetAttrDescription()
                };
            }
        }

        public static string GetDescriptions(Enum source) {
			var name = source.ToString();
			foreach (var memberInfo in source.GetType().GetMember(name)) {
				var attribute = (DescriptionsAttribute)memberInfo.GetCustomAttributes(typeof(DescriptionsAttribute), false).FirstOrDefault();
				var description = attribute != null ? attribute.Description : name;
				return description;
			}
			return string.Empty;
		}

        public static string GetCodePrifix(Enum source) {
			var name = source.ToString();
			foreach (var memberInfo in source.GetType().GetMember(name)) {
				var attribute = (CodePrefixAttribute)memberInfo.GetCustomAttributes(typeof(CodePrefixAttribute), false).FirstOrDefault();
				var description = attribute != null ? attribute.Prifix : name;
				return description;
			}
			return name;
		}

        public static string GetDescriptionFromValue(Enum source, string value) {
			var name = source.ToString();
			foreach (var memberInfo in source.GetType().GetMember(name)) {
				var attributes = (DescriptionsAttribute[])memberInfo.GetCustomAttributes(typeof(DescriptionsAttribute), false);
				foreach (var descriptionsAttribute in attributes) {
					var description = descriptionsAttribute != null ? descriptionsAttribute.Description : name;
					return description;
				}
			}
			return name;
		}

		public static string GetDescription(Enum source, string value) {
			var enumType = source.GetType();
			foreach (Enum enumSource in Enum.GetValues(enumType)) {
				var enumSourceValue = enumSource.ToString();
				if (enumSourceValue.Equals(value)) {
					return GetDescriptions(enumSource);
				}
			}

			return value;
		}

		public static string GetDescriptionByName<T>(T enumItemName) {
			FieldInfo fi = enumItemName.GetType().GetField(enumItemName.ToString());

			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			if (attributes.Length > 0) {
				return attributes[0].Description;
			}
			return enumItemName.ToString();
		}
	}

	public class EnumEntity
	{
		public int Value { get; set; }

		public string Name { get; set; }
	}
}
