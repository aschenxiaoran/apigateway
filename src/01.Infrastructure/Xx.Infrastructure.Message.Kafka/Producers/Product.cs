using System;

namespace Xx.Infrastructure.Message.Kafka.Producers {

    [Serializable]
    public class Product {
        public string Name { get; set; }
        public string Code { get; set; }

        public Product(string name, string code) {
            Name = name;
            Code = code;
        }
    }
}