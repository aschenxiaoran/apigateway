using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Hxf.Infrastructure.Utilities;

namespace Hxf.Infrastructure.Extensions {
    public static class StringExtension {
        public static bool EqualsIgnoreCase(this string source, string target) {
            if ((string.IsNullOrEmpty(source) && String.IsNullOrEmpty(target))) {
                return true;
            }

            if (string.IsNullOrEmpty(source)) {
                return false;
            }

            if (string.IsNullOrEmpty(target)) {
                return false;
            }

            if (target.Length != source.Length) {
                return false;
            }

            return String.Compare(source, target, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static string GetUriName(this string source) {
            if (string.IsNullOrWhiteSpace(source)) {
                return string.Empty;
            }

            var output = new StringBuilder();

            var hasInvaildCode = false;
            for (var i = 0; i < source.Length; i++) {
                var @char = source[i];
                if (char.IsLetterOrDigit(@char)) {
                    output.Append(@char);
                    hasInvaildCode = false;
                }
                else {
                    if (!hasInvaildCode) {
                        output.Append("-");
                        hasInvaildCode = true;
                    }
                }
            }

            return output.ToString().TrimEnd('-');
        }

        public static string GetLetterAndDigitString(this string source) {
            if (string.IsNullOrEmpty(source)) {
                return string.Empty;
            }

            var chars = source.ToCharArray().Where(char.IsLetterOrDigit).ToList();
            return string.Join("", chars);
        }

        public static string HtmlEncode(this string source) {
            if (string.IsNullOrEmpty(source)) {
                return string.Empty;
            }

            return WebUtility.HtmlEncode(source);
        }

        public static string HtmlDecode(this string source) {
            if (string.IsNullOrEmpty(source)) {
                return string.Empty;
            }

            return WebUtility.HtmlDecode(source);
        }

        public static bool IsNullOrEmpty(this string source) {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNotNullOrEmpty(this string source) {
            return !string.IsNullOrEmpty(source);
        }

        public static bool IsNullOrWhiteSpace(this string source) {
            return string.IsNullOrWhiteSpace(source);
        }

        public static bool IsNumericOnly(this string source) {
            if (string.IsNullOrEmpty(source)) {
                return false;
            }

            return source.All(Char.IsDigit);
        }

        public static string TrimIfNotEmpty(this string source, params char[] trimChars) {
            if (source == null) {
                return null;
            }

            if (trimChars == null || trimChars.Length == 0) {
                return source.Trim();
            }

            return source.Trim(trimChars);
        }

        //public static string Reverse(this string source) {
        //	if (IsNullOrEmpty(source)) {
        //		return source;
        //	}

        //	var charArray = source.ToCharArray();
        //	Array.Reverse(charArray);
        //	return new string(charArray);
        //}

        public static string FormatWith(this string source, params object[] args) {
            if (string.IsNullOrEmpty(source)) {
                return string.Empty;
            }

            return string.Format(source, args);
        }

        public static string FormatWith(this string source, Dictionary<string, string> parameters) {
            if (string.IsNullOrEmpty(source)) {
                return string.Empty;
            }

            var output = source;
            foreach (var parameter in parameters) {
                output = output.Replace(parameter.Key, parameter.Value);
            }

            return output;
        }

        public static string SubstringWith(this string source, int length) {
            if (source.IsNullOrWhiteSpace()) {
                return source;
            }
            if (source.Length <= length) {
                return source;
            }
            return source.Substring(0, length);
        }

        /// <summary>
        /// 确保字符长度不超过指定的长度
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="withEllipsis">是否显示省略号</param>
        /// <returns>Input string if its lengh is OK; otherwise, truncated input string</returns>
        public static string EnsureMaximumLength(this string source, int maxLength, bool withEllipsis = false) {
            if (string.IsNullOrEmpty(source)) {
                return source;
            }

            if (source.Length > maxLength) {
                string result = source.Substring(0, maxLength);
                if (withEllipsis) {
                    result += "..";
                }
                return result;
            }

            return source;
        }

        /// <summary>
        /// Ensures that a string only contains numeric values
        /// </summary>
        /// <param name="source">Input string</param>
        /// <returns>Input string with only numeric values, empty string if input is null/empty</returns>
        public static string EnsureNumericOnly(this string source) {
            if (string.IsNullOrEmpty(source)) {
                return String.Empty;
            }

            var result = new StringBuilder();
            foreach (char c in source) {
                if (Char.IsDigit(c)) {
                    result.Append(c);
                }
            }

            return result.ToString();
            //return source.Where(char.IsDigit).Aggregate(string.Empty, (sum, next) => sum + next);
        }

        /// <summary>
        /// Ensure that a string is not null
        /// </summary>
        /// <param name="source">Input string</param>
        /// <returns>Result</returns>
        public static string EnsureNotNull(this string source) {
            return source ?? String.Empty;
        }

        public static string EnsureTrim(this string str, params char[] trimChars) {
            if (str == null) {
                return null;
            }

            if (trimChars == null || trimChars.Length == 0) {
                return str.Trim();
            }

            return str.Trim(trimChars);

        }

        /// <summary>
        /// Indicates whether the specified strings are null or empty strings
        /// </summary>
        /// <param name="stringsToValidate">collection of strings to validate</param>
        /// <returns>Boolean</returns>
        public static bool AreNullOrEmpty(this ICollection<string> stringsToValidate) {
            return stringsToValidate.Any(String.IsNullOrEmpty);
        }

        /// <summary>
        /// Indicates whether the specified strings are numeric only
        /// </summary>
        /// <param name="stringsToValidate">collection of string to validate</param>
        /// <returns>Boolean</returns>
        public static bool AreNumericOnly(this ICollection<string> stringsToValidate) {
            if (stringsToValidate == null || stringsToValidate.Count == 0) {
                return false;
            }

            return stringsToValidate.Any(m => m.IsNumericOnly());
        }

        public static bool? ToBoolean(this string source) {
            if (string.Compare(source, "true", StringComparison.InvariantCultureIgnoreCase) == 0) {
                return true;
            }

            if (String.Compare(source, "false", StringComparison.InvariantCultureIgnoreCase) == 0) {
                return false;
            }

            return null;
        }

        public static long? ToInt64(this string source) {
            long result;
            if (Int64.TryParse(source, out result)) {
                return result;
            }

            return null;
        }

        public static double? ToDouble(this string source) {
            double result;

            if (double.TryParse(source, out result)) {
                return result;
            }

            return null;
        }

        public static float? ToFloat(this string source) {
            float result;
            if (float.TryParse(source, out result)) {
                return result;
            }

            return null;
        }

        public static decimal? ToDecimal(this string source) {
            decimal result;
            if (decimal.TryParse(source, out result)) {
                return result;
            }

            return null;
        }

        public static float? ToPersent(this string source) {
            if (string.IsNullOrEmpty(source)) {
                return null;
            }

            var result = source.TrimEnd('%').ToFloat();
            if (result != null) {
                return result.Value / 100.0f;
            }

            return null;
        }

        public static Decimal? ToDecimalPersent(this string source) {
            if (string.IsNullOrEmpty(source)) {
                return null;
            }

            var result = source.TrimEnd('%').ToFloat();
            if (result != null) {
                return (Decimal)(result.Value / 100.0f);
            }

            return null;
        }

        public static int? ToInt32(this string source) {
            int result;

            if (int.TryParse(source, out result)) {
                return result;
            }

            return null;
        }

        public static DateTime? ToDateTime(this string source) {
            DateTime result;

            if (DateTime.TryParse(source, out result)) {
                return result;
            }

            return null;
        }

        public static DateTime ToNotNullDateTime(this string source) {
            DateTime result;

            if (DateTime.TryParse(source, out result)) {
                return result;
            }

            return DateTime.MinValue;
        }

        public static Guid? ToGuid(this string source) {
            Guid result;

            if (Guid.TryParse(source, out result)) {
                return result;
            }
            return null;
        }

        public static DateTime? ToRuDateTime(this string source) {
            if (source == null) {
                return null;
            }
            var culture = new CultureInfo("ru-RU");
            try {
                return Convert.ToDateTime(source, culture);
            }
            catch (Exception) {
                return null;
            }

        }

        //public static string ToTitleCase(this string source)
        //{
        //    return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(source);
        //}

        //public static string ToTitileLower(this string source) {
        //    if (source.IsNullOrEmpty()) {
        //        return source;
        //    }
        //    var firstWord = source.Substring(0, 1).ToLower();
        //    var result = firstWord + source.Substring(1, source.Length - 1);
        //    return result;
        //}

        public static string ToPinYin(this string source) {
            return StringUtility.CharacterConvertString(source);
        }

        public static string ToFirstWord(this string source) {
            return source.IsNullOrWhiteSpace() ? source:source.Substring(0,1);
        }

        public static IList<int> ToModelList(this string modelIdList) {
            var modelList = new List<int>();
            if (!modelIdList.IsNullOrWhiteSpace()) {
                foreach (string modelId in modelIdList.Split(',')) {
                    var id = modelId.ToInt32() ?? 0;
                    if (id > 0) {
                        modelList.Add(id);
                    }

                }
            }
            return modelList;
        }

        public static IList<string> ToList(this string modelIdList) {
            var modelList = new List<string>();
            if (!modelIdList.IsNullOrWhiteSpace()) {
                foreach (string modelId in modelIdList.Split(',')) {
                    var id = modelId;
                    if (id.IsNotNullOrEmpty()) {
                        modelList.Add(id);
                    }

                }
            }
            return modelList;
        }

        public static string GetHash(this string input) {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }



        public static byte[] ToByteArray(this string source) {
            return Activator.CreateInstance<ASCIIEncoding>().GetBytes(source);
        }
    }





}
