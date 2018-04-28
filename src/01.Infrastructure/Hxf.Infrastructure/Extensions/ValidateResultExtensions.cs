using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.Extensions
{
	public static class ValidateResultExtensions {
		public static IValidationErrors ToValidationError(this ValidationResult validationResult) {
			var validationError = new ValidationErrors();

			foreach (var failure in validationResult.Errors) {
				validationError.AddError(failure.PropertyName, failure.AttemptedValue, failure.ErrorMessage, false);
			}

			return validationError;
		}

		public static IValidationErrors DoValidate<T>(this IValidator<T> validator, T instance, string ruleSet = null) {
			var validationResult = validator.Validate(instance, ruleSet: ruleSet);

			var validationError = new ValidationErrors();

			foreach (var failure in validationResult.Errors) {
				validationError.AddError(failure.PropertyName, failure.AttemptedValue, failure.ErrorMessage, false);
			}

			return validationError;
		}

        public static async Task<IValidationErrors> DoValidateAsync<T>(this IValidator<T> validator, T instance, string ruleSet = null,object validateKey=null) {
			var validationResult = await validator.ValidateAsync(instance, ruleSet: ruleSet);

			var validationError = new ValidationErrors();
            validateKey = validateKey ?? string.Empty;

			foreach (var failure in validationResult.Errors) {
				validationError.AddError(failure.PropertyName, failure.AttemptedValue, failure.ErrorMessage, false,validateKey.ToString());
			}

			return validationError;
		}


	}
}