using System;

namespace Hxf.Infrastructure.Extensions {
    public static class DecimalExtension {
        /// <summary>
        /// 转换为两个小数点的非空decimal类型
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal ToDecimalTwoPoint(this decimal? source) {
            if (source == null) {
                return 0;
            }
            else {
                return Math.Round(source.Value, 2);
            }
        }

        /// <summary>
        ///  转换为两个小数点的string类型
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDecimalTwoPointString(this decimal? source) {
            return ToDecimalTwoPoint(source).ToString();
        }

        /// <summary>
        /// 转换为%
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToPercent(this decimal? source) {
            return source.ToDecimalTwoPoint().ToString("p");
        }

        public static string ToFString(this decimal? source, string formatPattern) {
            return source != null ? source.Value.ToString(formatPattern) : "0";
        }

        public static string ToFString(this DateTime? source, string formatPattern) {
            return source != null ? source.Value.ToString(formatPattern) : "0";
        }

        public static decimal Divide(this decimal source, decimal target) {
            if (target == 0M) { return 0M; }
            return source/target;
        }

        public static decimal Divide(this decimal source, decimal? target) {
            if (target==null || target == 0M) { return 0M; }
            return source/target.Value;
        }

        public static decimal Divide(this decimal? source, decimal? target) {
            if (source==null ||target==null || target == 0M) { return 0M; }
            return source.Value/target.Value;
        }
    }
}
