using System;
using System.Collections.Generic;
using Hxf.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hxf.Infrastructure.Extensions {
    public static class EnumExtension {
        public static T GetAttribute<T>(this Enum value) where T : Attribute {
            var field = value.GetType().GetField(value.ToString());
            return Attribute.GetCustomAttribute(field, typeof(T)) as T;
        }

        public static string GetAttrDescription(this Enum value) {
            return GetAttribute<DescriptionsAttribute>(value).ToString();
        }

        public static IEnumerable<SelectItem> GetEnumItem<T>() {
            Type type = typeof(T);
            if (!type.IsEnum) {
                throw new ArgumentException("传入的参数必须是枚举类型！", "EnumType");
            }
            yield return new SelectItem { Value = "", Text = "请选择",Name = "请选择"};
            foreach (Enum enumValue in Enum.GetValues(type)) {
                yield return new SelectItem {
                    Id = Convert.ToInt32(enumValue),
                    Value = Convert.ToInt32(enumValue).ToString(),
                    Text = enumValue.GetAttrDescription(),
                    Name = enumValue.GetAttrDescription()
                };
            }
        }

       

        public static IEnumerable<SelectListItem> GetEnumDic<T>() {
            Type type = typeof(T);
            if (!type.IsEnum) {
                throw new ArgumentException("传入的参数必须是枚举类型！", "EnumType");
            }
            yield return new SelectListItem() { Value = "", Text = "请选择" };
            foreach (Enum enumValue in Enum.GetValues(type)) {
                yield return new SelectListItem() { Value = Convert.ToInt32(enumValue).ToString(), Text = enumValue.GetAttrDescription() };
            }
        }
    }

    public class SelectItem {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Text { get; set; }
    }
}
