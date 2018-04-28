using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace Hxf.Infrastructure.Validation.Validators {
	public class ObjectRegularExpressionValidator : RegularExpressionValidator {
		protected readonly Regex Regex;


		public ObjectRegularExpressionValidator(string expression) : base(expression) {
			Regex = new Regex(expression);

		}

		public ObjectRegularExpressionValidator(Regex regex) : base(regex) {
			Regex = regex;
		
		}

		public ObjectRegularExpressionValidator(string expression, RegexOptions options) : base(expression, options) {
			Regex = new Regex(expression, options);
		
		}

		protected override bool IsValid(PropertyValidatorContext context) {
			var propertyValue = context.PropertyValue;
			if (propertyValue == null) {
				return true;
			}

			var stringValue = propertyValue.ToString();
			return Regex.IsMatch(stringValue);
		}
	}
}