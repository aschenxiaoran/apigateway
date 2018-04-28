using System;
using System.Text;
using Hxf.Infrastructure.Extensions;

namespace Hxf.Infrastructure.Security
{
    public class StringGenerater {
        public static readonly string[] Alphabet = {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
            "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };

        public static readonly string[] AlphabetAndNumbers = {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B",
            "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
            "Y", "Z"
        };

        public static string GetString(byte[] value) {
            return GetString(value, AlphabetAndNumbers);

        }

        public static string GetString(byte[] value, string[] map) {
            if (value == null || value.Length == 0) {
                return "";
            }

            var builder = new StringBuilder();

            for (var startIndex = 0; startIndex <= value.Length - 8; startIndex = startIndex + 8) {
                var uInt64 = BitConverter.ToUInt64(value, startIndex);
                var part = GetString(uInt64, map);
                builder.Append(part);
            }

            return builder.ToString();
        }

        public static string GetString(ulong value) {
            return GetString(value, AlphabetAndNumbers);
        }

        public static string GetString(ulong value, string[] map) {
            if (map == null || map.Length == 0) {
                return "";
            }

            var length = (uint)map.Length;

            var output = "";
            while (value >= length) {
                var index = value % length;
                value = value / length;
                output = map[index] + output;
            }

            output = map[value] + output;

            return output;
        }

        public static ulong GetValue(string encodeString) {
            return GetValue(encodeString, AlphabetAndNumbers);
        }

        public static ulong GetValue(string encodeString, string[] map) {
            if (map == null || map.Length == 0 || encodeString.IsNullOrEmpty()) {
                return 0;
            }

            var result = 0;
            foreach (var c in encodeString.ToCharArray()) {
                unchecked {
                    result = (result * map.Length + Array.IndexOf(map, new string(new[] { c })));
                }
            }

            return (ulong)result;
        }
    }
}