namespace Hxf.Infrastructure.Extensions {
    public static class IntegerExtensions {

        public static string ToFString(this int? source) {
            var result = 0;
            result = source ?? result;
            return result.ToString();
        }
    }
}
