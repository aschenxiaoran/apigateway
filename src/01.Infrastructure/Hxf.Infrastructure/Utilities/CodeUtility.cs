using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hxf.Infrastructure.Enums;
using Hxf.Infrastructure.Extensions;

namespace Hxf.Infrastructure.Utilities {
    public class CodeUtility {
        private static readonly object LockHelper = new object();

        private static Random random = new Random((int)DateTime.Now.Ticks);

        private static List<int> GenerateRandom(int count, int min, int max) {
            if (max <= min || count < 0 ||
                    // max - min > 0 required to avoid overflow
                    (count > max - min && max - min > 0)) {
                // need to use 64-bit to support big ranges (negative min, positive max)
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                        " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
            }

            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();

            // start count values before max, and end at max
            for (int top = max - count; top < max; top++) {
                // May strike a duplicate.
                // Need to add +1 to make inclusive generator
                // +1 is safe even for MaxVal max value because top < max
                if (!candidates.Add(random.Next(min, top + 1))) {
                    // collision, add inclusive max.
                    // which could not possibly have been added before.
                    candidates.Add(top);
                }
            }

            // load them in to a list, to sort
            List<int> result = candidates.ToList();

            // shuffle the results because HashSet has messed
            // with the order, and the algorithm does not produce
            // random-ordered results (e.g. max-1 will never be the first value)
            for (int i = result.Count - 1; i > 0; i--) {
                int k = random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }

            return result;
        }

        public string Code { get; set; }

        /// <summary>
        /// 获取动态随机字符串
        /// </summary>
        /// <param name="randomLength">随机数字字符串长度</param>
        /// <returns></returns>
        private static string GenerateRandomString(int randomLength) {
            List<int> hashArray = GenerateRandom(randomLength, 0, Int32.MaxValue);

            StringBuilder sb = new StringBuilder();

            foreach (int randomNumber in hashArray) {
                if (sb.Length >= randomLength)
                    break;

                sb.Append(randomNumber);
            }

            return sb.Remove(randomLength, sb.Length - randomLength).ToString();
        }

        public static string RanCode {
            get {
                lock (LockHelper) {
                    return String.Join("", GenerateRandomString(12).ToArray());
                }
            }
        }
        public static string DbCode {
            get {
                lock (LockHelper) {
                    return String.Join("", GenerateRandomString(12).ToArray());
                }
            }
        }

        public static string GuidCode {
            get {
                lock (LockHelper) {
                    return Guid.NewGuid().ToString();
                }
            }
        }

        public static string TreatyOddNumber {
            get {
                lock (LockHelper) {
                    return DateTime.Now.ToString("yyMMdd") + DateTime.Now.Ticks.ToString().Substring(9);
                }
            }
        }

        public static string TreatyApplyNo {
            get {
                lock (LockHelper) {
                    return "SQ" + DateTime.Now.ToString("yyyyMMdd") + RanCode.Substring(7);
                }
            }
        }
        public static string TreatyReturnNo {
            get {
                lock (LockHelper) {
                    return "TH" + DateTime.Now.ToString("yyyyMMdd") + RanCode.Substring(7);
                }
            }
        }

        public static string RanAddress {
            get {
                var address = "四川省成都市蓝光圣菲" + RanCode;
                return address;
            }
        }

        public static string RanTel {
            get {
                var tel = "028-888888888";
                return tel;
            }
        }
        public static string RanMobile {
            get {
                var tel = "15828140730";
                return tel;
            }
        }

        public static string RanEmail {
            get {
                var tel = RanCode + "@163.com";
                return tel;
            }
        }

        public static string RanIdentityCartNo {
            get {
                var identityCartNo = "450211198612060235";
                return identityCartNo;
            }
        }

        public static decimal RanDecimal {
            get {
                Random random = new Random(Environment.TickCount);
                return Decimal.Round(Convert.ToDecimal(random.NextDouble() * 1000), 2);
            }
        }

        public static int RandomId {
            get {
                Random random = new Random(Environment.TickCount);
                return random.Next(1000);
            }
        }

        public static DateTime? DateTimeNow {
            get { return DateTime.Now; }
        }

        public static bool RanBool { get { return DateTime.Now.Second % 2 == 0; } }

        public static string FillZeroForCode(int length, string codeNum) {
            var builder = new StringBuilder(codeNum);

            while (builder.Length < length) {
                builder.Insert(0, "0");
            }

            return builder.ToString();
        }

        public static string CreateCode(string orignalCode, TotalBillTypeEnum billType) {
            var codePrefix = GetCodePrifix(billType);
            var codeArray = GetCodeArray(orignalCode, billType);
            var billCode = CombinBillCode(codeArray, codePrefix);
            return billCode;
        }

        private static string CombinBillCode(IList<string> codeArray, string codePrefix) {
            if (codeArray.Count != 3) {
                throw new CreateCodeException();
            }
            var codeDay = codeArray[1];
            var codeSortIndex = (codeArray[2].ToInt32() ?? 0) + 1;
            var codeLast = FillZeroForCode(4, codeSortIndex.ToString());
            string billCode = $"{codePrefix}-{codeDay}-{codeLast}";
            return billCode;
        }

        private static List<string> GetCodeArray(string orignalCode, TotalBillTypeEnum billType) {
            var nowDay = DateTime.Now.ToString("yyyyMMdd").ToLower();
            if (orignalCode.IsInValid()) {
                orignalCode = $"{GetCodePrifix(billType)}-{nowDay}-0000";
            }

            var codeArray = orignalCode.Split('-').ToList();
            if (codeArray.Count != 3) {
                throw new CreateCodeException();
            }
            codeArray[2] = (codeArray[1].ToInt32() == nowDay.ToInt32()) ? codeArray[2] : "0000";
            codeArray[1] = nowDay;
            return codeArray;
        }

        private static string GetCodePrifix(TotalBillTypeEnum billType) {
            var codePrifix = EnumUtility.GetCodePrifix(billType);
            return codePrifix;
        }

        #region 废弃的代码前缀，统一用CreateCode方法调用

        /// <summary>
        /// 付款单前缀
        /// </summary>
        public static string FinancePayCodePre {
            get {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                var codePre = $"FK-{dateString}-";

                return codePre;
            }
        }

        public static string FinanceReceiveCodePre {
            get {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                var codePre = $"SK-{dateString}-";

                return codePre;
            }
        }

        public static string FinanceFeeCodePre {
            get {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                var codePre = $"FY-{dateString}-";

                return codePre;
            }
        }

        public static string FinanceTransferCodePre {
            get {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                var codePre = $"NBZZ-{dateString}-";

                return codePre;
            }
        }

        public static string FinanceOtherPayCodePre {
            get {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                var codePre = $"QTSR-{dateString}-";

                return codePre;
            }
        }

        /// <summary>
        /// 销售订单前缀
        /// </summary>
        public static string SaleOrderCodePre {
            get {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                var codePre = $"XSDD-{dateString}-";

                return codePre;
            }
        }

        /// <summary>
        /// 销售出库单前缀
        /// </summary>
        public static string SaleOutCodePre {
            get {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                var codePre = $"XSCKD-{dateString}-";

                return codePre;
            }
        }

        #endregion
    }
}