using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml;
using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Entities {
    public class Entity : IEntity {
        #region public methods

        /// <summary>
        /// ��ʵ�帽ֵ.
        /// 
        /// </summary>
        /// <param name="json">json��ʽ����.</param>
        public void SetValues(string json) {

        }

        /// <summary>
        /// ��ʵ�帽ֵ.
        /// 
        /// </summary>
        /// <param name="xmlDoc">XmlDocument��ʽ����.</param>
        public void SetValues(XmlDocument xmlDoc) {
            try {
                Type type = GetType();
                if (xmlDoc.DocumentElement != null) {
                    var childNodes = xmlDoc.DocumentElement.ChildNodes;
                    for (int index = 0; index < childNodes.Count; ++index) {
                        XmlNode xmlNode = childNodes[index];
                        PropertyInfo property = type.GetProperty(xmlNode.Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                        if (!IsNullOrEmpty(property) && property.CanWrite) {
                            if (property.PropertyType.BaseType != null && property.PropertyType.BaseType.Name == "Enum") {
                                property.SetValue((object)this, Enum.Parse(property.PropertyType, xmlNode.InnerText, true), (object[])null);
                            }
                            else {
                                try {
                                    property.SetValue(this, GetObjectType(xmlNode.InnerText, property), null);
                                }
                                catch {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex);
            }
        }

        public void SetValues(XmlNodeList xnl) {
            try {
                Type type = this.GetObjectType();
                for (int index = 0; index < xnl.Count; ++index) {
                    XmlNode xmlNode = xnl[index];
                    PropertyInfo property = type.GetProperty(xmlNode.Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (!IsNullOrEmpty(property) && property.CanWrite) {
                        if (property.PropertyType.BaseType.Name == "Enum") {
                            property.SetValue((object)this, Enum.Parse(property.PropertyType, xmlNode.InnerText, true), (object[])null);
                        }
                        else {
                            try {
                                property.SetValue((object)this, this.GetObjectType((object)xmlNode.InnerText, property), (object[])null);
                            }
                            catch {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// ��ʵ�帽ֵ.
        /// 
        /// </summary>
        /// <param name="dic">Hashtable��ʽ����.</param>
        public void SetValues(Dictionary<string, object> dic) {
            try {
                Type type = GetObjectType();
                if (dic == null)
                    return;
                foreach (KeyValuePair<string, object> keyValuePair in dic) {
                    PropertyInfo property = type.GetProperty(keyValuePair.Key.Trim(), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (!IsNullOrEmpty(property) && property.CanWrite) {
                        if (property.PropertyType.BaseType != null && property.PropertyType.BaseType.Name == "Enum") {
                            property.SetValue(this, Enum.Parse(property.PropertyType, keyValuePair.Value.ToString(), true), null);
                        }
                        else {
                            try {
                                property.SetValue(this, GetObjectType(keyValuePair.Value, property), null);
                            }
                            catch {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region private methods

        private Type GetObjectType() {

            Type type = this.GetType();

            return type;
        }

        private object GetObjectType([In] object obj0, [In] PropertyInfo obj1) {
            if (obj0 == null)
                return null;
            Type nullableType = GetNullableType(obj1.PropertyType);

            if (obj0.ToString() == "" && (nullableType.Name == "Int32" || nullableType.Name == "Int64")) {
                return null;
            }

            if (nullableType.Name == "bool" || nullableType.Name == "Boolean") {
                obj0 = obj0.ToString() != "1" && obj0.ToString().ToLower() != "true" ? false : (object)true;
            }
            else if (nullableType.Name == "string" || nullableType.Name == "String") {

                object[] customAttributes = obj1.GetCustomAttributes(typeof(EntityPropertyAttribute), true);

                if (customAttributes.Length == 1) {
                    var propertyAttribute = customAttributes.GetValue(0) as EntityPropertyAttribute;
                    if (propertyAttribute != null && propertyAttribute.Format != PropertyFormat.Html)
                        obj0 = HtmlUtility.EncodeHtml(obj0.ToString());
                }
                else {
                    obj0 = HtmlUtility.EncodeHtml(obj0.ToString());
                }

            }
            else if (nullableType.Name.ToLower() == "int32" || nullableType.Name.ToLower() == "int64") {
                obj0 = Convert.ToInt32(obj0);
            }

            try {
                return Convert.ChangeType(obj0, nullableType, CultureInfo.CurrentCulture);
            }
            catch {
                if (obj0 == null)
                    return null;
                if (nullableType.Name == "DateTime")
                    obj0 = new DateTime(1900, 0, 0);
                else if (nullableType == typeof(int) || nullableType == typeof(Decimal) || nullableType == typeof(double))
                    obj0 = 0;
                return Convert.ChangeType(obj0, nullableType, CultureInfo.CurrentCulture);
            }
        }

        private static bool IsNullOrEmpty(object data) {
            return data == null || data.ToString() == "" || data is DBNull;
        }

        /// <summary>
        /// ��ȡ���п����͵�׼ȷ��������.
        /// 
        /// </summary>
        /// <param name="type">����.</param>
        /// <returns>
        /// System.Type
        /// 
        /// </returns>
        private static Type GetNullableType(Type type) {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type.GetGenericArguments()[0];
            return type;
        }

        #endregion

        public int Id { get; set; }
    }

    public abstract class BaseEntity : Entity, IEntity {

        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public new int Id { get; set; }



        //public override bool Equals(object obj)
        //{
        //    return Equals(obj as BaseEntity);
        //}

        //private static bool IsTransient(BaseEntity obj)
        //{
        //    return obj != null && Equals(obj.Id, default(int));
        //}

        //private Type GetUnproxiedType()
        //{
        //    return GetType();
        //}

        //public virtual bool Equals(BaseEntity other)
        //{
        //    if (other == null)
        //        return false;

        //    if (ReferenceEquals(this, other))
        //        return true;

        //    if (!IsTransient(this) &&
        //        !IsTransient(other) &&
        //        Equals(Id, other.Id))
        //    {
        //        var otherType = other.GetUnproxiedType();
        //        var thisType = GetUnproxiedType();
        //        return thisType.IsAssignableFrom(otherType) ||
        //                otherType.IsAssignableFrom(thisType);
        //    }

        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    if (Equals(Id, default(int)))
        //        return base.GetHashCode();
        //    return Id.GetHashCode();
        //}

        //public static bool operator ==(BaseEntity x, BaseEntity y)
        //{
        //    return Equals(x, y);
        //}

        //public static bool operator !=(BaseEntity x, BaseEntity y)
        //{
        //    return !(x == y);
        //}
    }



    public class HtmlUtility {

        /// <summary>
        /// �滻html�ַ�
        /// 
        /// </summary>
        public static string EncodeHtml(string str) {
            if (!string.IsNullOrEmpty(str)) {
                return HttpUtility.HtmlEncode(str);
            }
            return "";
        }
    }
}