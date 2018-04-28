using System;
using System.Collections.Generic;

namespace Hxf.Infrastructure.Extensions {
    public static class DateTimeExtension {

        public static bool IsValid(this DateTime source) {
            return source != DateTime.MinValue && source != DateTime.MaxValue;
        }

        public static bool IsValid(this DateTime? source) {
            return source != null && source.Value != DateTime.MinValue && source.Value != DateTime.MaxValue;
        }

        public static string ToShortDateString(this DateTime? source) {
            return source?.ToShortDateString() ?? String.Empty;
        }

        public static DateTime? ToStartTime(this DateTime? source) {
            if (source != null) {
                return source.Value.AddSeconds(-1);
            }
            return null;
        }

        public static DateTime? ToEndTime(this DateTime? source) {
            if (source != null) {
                return source.Value.AddDays(1).AddSeconds(-1);
            }
            return null;
        }

        public static DateTime ToStartTime(this DateTime source) {
            return source.AddSeconds(-1);
        }

        public static DateTime ToEndTime(this DateTime source) {
            return source.AddDays(1).AddSeconds(-1);
        }
        public static string ToFormatTime(DateTime? date) {
            return date != null ?
                $"{date.Value.Year}年{date.Value.Month}月{date.Value.Day}日 {date.Value.ToShortTimeString()}"
                : string.Empty;
        }

        public static DateTime? ToMonthFirstDay(this DateTime dateTime) {
            var monthFirstDay = $"{dateTime.Year}-{dateTime.Month}-01".ToDateTime();
            return monthFirstDay;
        }

        public static DateTime? ToMonthLastDay(this DateTime dateTime) {
            var monthFirstDay = $"{dateTime.Year}-{dateTime.Month}-01".ToDateTime();
            var monthLastDay = monthFirstDay?.AddMonths(1).AddSeconds(-1);
            return monthLastDay;
        }


        public static DateTime Tommorrow(this DateTime source) {
            return source.ToShortDateString().ToNotNullDateTime().AddDays(1);
        }

        /// <summary>
        /// 获取上月时间范围
        /// </summary>
        /// <param name="today">DateTime.Today</param>
        /// <returns></returns>
        public static KeyValuePair<DateTime, DateTime> GetLastMonthDataRange(this DateTime today)
        {
            today = DateTime.Today;
            return new KeyValuePair<DateTime, DateTime>(new DateTime(today.Year, today.Month, 1).AddMonths(-1), new DateTime(today.Year, today.Month, 1).Subtract(TimeSpan.FromSeconds(1.00)));
        }

        /// <summary>
        /// 获取本月时间范围
        /// </summary>
        /// <param name="today">DateTime.Today</param>
        /// <returns></returns>
        public static KeyValuePair<DateTime, DateTime> GetThisMonthDataRange(this DateTime today)
        {
            today = DateTime.Today;
            return new KeyValuePair<DateTime, DateTime>(new DateTime(today.Year, today.Month, 1), today.AddDays(1.00).Subtract(TimeSpan.FromSeconds(1.00)));
        }

        /// <summary>
        /// 获取明日时间范围
        /// </summary>
        /// <param name="today">DateTime.Today</param>
        /// <returns></returns>
        public static KeyValuePair<DateTime, DateTime> GetTomorrowDataRange(this DateTime today)
        {
            today = DateTime.Today;
            return new KeyValuePair<DateTime, DateTime>(today.AddDays(1.00),  today.AddDays(2.00).Subtract(TimeSpan.FromSeconds(1.00)));
        }

        /// <summary>
        /// 获取当日时间范围
        /// </summary>
        /// <param name="today">DateTime.Today</param>
        /// <returns></returns>
        public static KeyValuePair<DateTime, DateTime> GetTodayDataRange(this DateTime today)
        {
            today = DateTime.Today;
            return new KeyValuePair<DateTime, DateTime>(today, today.AddDays(1.00).Subtract(TimeSpan.FromSeconds(1.00)));
        }

        /// <summary>
        /// 获取昨日时间范围
        /// </summary>
        /// <param name="today">DateTime.Today</param>
        /// <returns></returns>
        public static KeyValuePair<DateTime, DateTime> GetYesterdayDataRange(this DateTime today)
        {
            today = DateTime.Today;
            return new KeyValuePair<DateTime, DateTime>(today.AddDays(-1.00), today.Subtract(TimeSpan.FromSeconds(1.00)));
        }
    }
}
