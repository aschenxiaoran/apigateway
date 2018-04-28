using System.IO;
using Newtonsoft.Json;

namespace Hxf.Infrastructure.Utilities {
    public class JsonUtility {

        public static string Serialize(object source) {
            string json = JsonConvert.SerializeObject(source);
            return json;
        }

        public static T Deserialize<T>(string json) where T : class {
            var serializer = new JsonSerializer();
            var reader = new StringReader(json);
            T result = serializer.Deserialize<T>(new JsonTextReader(reader));
            return result;
        }
    }
}
