using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hxf.Infrastructure.Utilities {
    public class ByteUtility {
        public static byte[] Serialize<T>(T obj) {
            if (obj == null) {
                return null;
            }
            using (MemoryStream ms = new MemoryStream()) {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        public static T Deserialize<T>(byte[] bytes) {
            if (bytes == null) {
                return default(T);
            }
            using (MemoryStream ms = new MemoryStream(bytes)) {
                ms.Position = 0;
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
