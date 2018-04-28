using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Hxf.Infrastructure.Utilities {

    /// <summary>
    /// XML工具类
    /// </summary>
    public class XmlUtility
    {

        /// <summary>
        /// 对象到XML-----泛类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {

            if (obj == null)
                return String.Empty;

            var serializer = new XmlSerializer(typeof(T));

            // 清除多余命名空间代码xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd = "http://www.w3.org/2001/XMLSchema"
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var stream = new MemoryStream();
            var xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;

            try
            {
                serializer.Serialize(stream, obj, namespaces);
            }
            catch
            {
                return String.Empty;
            }

            stream.Position = 0;

            StringBuilder sb = new StringBuilder();

            using (var sr = new StreamReader(stream, Encoding.UTF8))
            {

                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    sb.Append(line);
                }
            }

            string xmlContent = sb.ToString();
            sb.Clear();

            if (xmlContent.Length > 0)
            {
                var length = "<?xml version='1.0'?>".Length;
                xmlContent = xmlContent.Substring(length, xmlContent.Length - length);
            }

            return xmlContent;
        }

        public static string ServializeNotEnd<T>(T obj)
        {
            var serializeObj = Serialize(obj);

            if (string.IsNullOrEmpty(serializeObj))
            {
                return serializeObj;
            }

            serializeObj = serializeObj.Substring(0, serializeObj.Length - 2);

            return serializeObj + ">";
        }

        /// <summary>
        /// XML到反序列化到对象----支持泛类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string data)
        {
            using (var stream = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream, Encoding.UTF8))
                {
                    sw.Write(data);
                    sw.Flush();
                    stream.Seek(0, SeekOrigin.Begin);

                    var serializer = new XmlSerializer(typeof(T));

                    try
                    {
                        return ((T)serializer.Deserialize(stream));
                    }
                    catch
                    {
                        return default(T);
                    }
                }
            }
        }
    }	
}
