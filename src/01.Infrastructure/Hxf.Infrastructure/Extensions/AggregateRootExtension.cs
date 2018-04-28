using System.Text;

namespace Hxf.Infrastructure.Extensions {
    public static class AggregateRootExtension {
        public static string MergeField(this IAggregateRoot entity, string[] column, string separator = "-") {
            var sb = new StringBuilder();
            foreach (var c in column) {
                var t = entity.GetType().GetProperty(c, typeof(string));
                var value = t != null ? t.GetValue(entity) : null;
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString())) {
                    sb.Append(value.ToString());
                    sb.Append("-");
                }
            }
            return sb.ToString();
        }
    }
}