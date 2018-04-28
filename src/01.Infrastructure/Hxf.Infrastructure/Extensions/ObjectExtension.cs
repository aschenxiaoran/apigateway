using System;

namespace Hxf.Infrastructure.Extensions {
    public static class ObjectExtension {
        
        public static bool TryConvert<T>(this object obj, out T result) {
            try {
                var converted = Convert.ChangeType(obj, typeof(T));
                if (converted is T) {
                    result = (T)converted;
                    return true;
                }
            }
            catch {

            }

            result = default(T);
            return false;
        }

        public static T ConvertTo<T>(this object obj) {
            try {
                var converted = Convert.ChangeType(obj, typeof(T));
                if (converted is T) {
                    return (T)converted;
                }
            }
            catch {

            }

            return default(T);
        }
    }
}
