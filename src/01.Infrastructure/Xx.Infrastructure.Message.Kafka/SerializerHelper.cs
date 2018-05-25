using Newtonsoft.Json;

namespace Xx.Infrastructure.Message.Kafka {
    public class SerializerHelper {
        public static string Serialize(object souce) {
            var json = JsonConvert.SerializeObject(souce);
            return json;
        }
    }
}