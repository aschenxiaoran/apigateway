namespace Hxf.Infrastructure.Utilities
{
    public static class ValidateUtility
    {
        public static bool IsDecimal(this object data)
        {
            if (data == null)
                return false;

            decimal temp = 0.0M;

            return decimal.TryParse(data.ToString(), out temp);
        }

        public static bool IsPositiveDecimal(this object data)
        {
            if (data == null)
                return false;

            decimal temp = 0.0M;

            return decimal.TryParse(data.ToString(), out temp) && temp > 0.0M;
        }

        public static bool IsInt(this object data)
        {
            if (data == null)
                return false;

            int temp = 0;

            return int.TryParse(data.ToString(), out temp);
        }

        public static bool IsPositiveInt(this object data)
        {
            if (data == null)
                return false;

            int temp = 0;

            return int.TryParse(data.ToString(), out temp) && temp > 0;
        }
    }
}
