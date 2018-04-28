namespace Hxf.Infrastructure.Constants
{
    public static class FinanceStatusConstants {

        public const string Draft = "Draft";
        public const string Cancel = "Cancel";
        public const string Payed = "Payed";
        public const int No = -999;
    }

    public static class TotalBillTypeConstants {

        public const string Receive = "Receive";
        public const string Cancel = "Cancel";
        public const string Payed = "Payed";
        public const int No = -1;
    }

    /// <summary>
    /// 收支类型衡量
    /// </summary>
    public static class BalanceTypeConstants {

        public const string Fee = "Fee";
        public const string Income = "Income";
        public const int No = -1;
    }
}