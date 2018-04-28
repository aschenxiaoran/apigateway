using System;

namespace Hxf.Infrastructure.Attributes {

    /// <summary>
    /// 描述属性
    /// </summary>
    public class DescriptionsAttribute : Attribute {

        public DescriptionsAttribute(string description) {
            Description = description;
        }

        public string Description { get; set; }

        public override string ToString() {
            return this.Description;
        }
    }

    /// <summary>
    /// 代码前缀
    /// </summary>
    public class CodePrefixAttribute : Attribute {

        public CodePrefixAttribute(string prifix) {
            Prifix = prifix;
        }

        public string Prifix { get; set; }

        public override string ToString() {
            return this.Prifix;
        }
    }
}
