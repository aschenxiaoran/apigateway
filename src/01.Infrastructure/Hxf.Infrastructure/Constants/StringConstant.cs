namespace Hxf.Infrastructure.Constants {
    public static class StringConstant {
        public const string AllDigitAndLetters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string ReadabilityDigitAndLetters = "23467acdefhjkmnpqrtwxyzACDEFGHJKLMNPQRTWXYZ";

        public const string TelRegexPattern = @"^(\d{3,4}-)?\d{6,8}$";
        public const string MobileRegexPattern = @"^(13([0-9])|15([0-9])|18([0-9]))\d{8}$";
        public const string EmailRegexPattern = @"^[a-zA-Z0-9_\+-]+(\.[a-zA-Z0-9_\+-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.([a-zA-Z]{2,4})$";
        public const string EmailAllowSpaceRegexPattern = @"^\s*[a-zA-Z0-9_\+-]+(\.[a-zA-Z0-9_\+-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.([a-zA-Z]{2,4})\s*$";

        public const string SkidCodeRegexPattern=@"^(\+|-)\d{8}$";

        public const string ZipCodeRegexPattern = @"^\d{6}$";

        public const string PositiveIntegerRegularPattern = "[0-9]*";
        public const string PositiveNumberRegularPattern = @"^((\d+(\.\d+)?)|0)$";
        public const string PositiveFloatNumberRegularPattern = @"^(([1-9]\d*(\.\d+)?))$";
        public const string PositiveFloatNumberContainZeroRegularPattern = @"^([0-9]\d*)(\.\d+)?$";
        public const string PositiveIntegerNumberRegularPattern = @"^[1-9]\d*$";
        public const string PositiveIntegerNumberContainZeroRegularPattern = @"^([0-9]*)$";

        public const string RequiredErrorMessage = "this field is required!";
        public const string StringLengthErrorMessage = "This field should less than or equal to {1} characters";
        public const string EmailErrorMessage = "please enter email with 'xxxx@xxx.xxx'";
        public const string InvalidErrorMessage = "this field is invalid";
        public const string DigitRangeErrorMessage = "The {0} must be digit and between {1} and {2}";
        public const string DigitErrorMessage = "must be digit";

        public const string UrlRegexPattern = @"(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?";
        public const string NumericRegexPattern = @"[0-9]+([.][0-9]{1,})?";
        public const string NumericMultiZeroPattern = @"(\^)?[0]{2}(\$)?";
    }
}