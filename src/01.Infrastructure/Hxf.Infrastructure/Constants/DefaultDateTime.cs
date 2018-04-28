using System;

namespace Hxf.Infrastructure.Constants {
    public static class DefaultDateTime {

        public static DateTime BeginTime {
            get {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                return DateTime.Parse($"{year}-{month}-1");
            }
        }

    }
}
