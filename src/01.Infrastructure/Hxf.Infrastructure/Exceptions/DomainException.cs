using System;
using System.Linq.Expressions;
using Hxf.Infrastructure.Attributes;
using Hxf.Infrastructure.Utilities;
using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.Exceptions {
	/// <summary>
	/// 业务逻辑异常
	/// </summary>
	[Serializable]
	public class DomainException : Exception {
		public IValidationErrors ValidationErrors { get; private set; }

		public DomainException() {
			ValidationErrors = new ValidationErrors();
		}

		public DomainException(IValidationErrors validationErrors, ValidationErrorType errorType = ValidationErrorType.Body) {
			ValidationErrors = validationErrors;
			foreach (var validationError in ValidationErrors.ErrorItems) {
				validationError.ErrorType = EnumUtility.GetDescriptions(errorType);
			}
		}

		public IValidationErrors AddError<TObject, TProperty>(Expression<Func<TObject, TProperty>> expression, object attemptedValue, string errorMessage, bool customState = false) {
			var memberExpression = expression.Body as MemberExpression;
			if (memberExpression != null)
				return ValidationErrors.AddError(memberExpression.Member.Name, errorMessage, attemptedValue, customState);
			return new ValidationErrors();
		}

		public IValidationErrors AddError(string propertyName, object attemptedValue, string errorMessage, bool customState = false) {
			if (!string.IsNullOrWhiteSpace(propertyName))
				return ValidationErrors.AddError(propertyName, errorMessage, attemptedValue, customState);
			return new ValidationErrors();
		}

		public static TException Create<TException>(IValidationErrors errors) where TException : DomainException, new() {
			var exception = new TException();
			if (errors != null) {
				exception.ValidationErrors = errors;
			}

			return exception;
		}
	}

	public class RepeateCodeException : Exception {

	}

	public enum ValidationErrorType {
		[Descriptions("Body")]
		Body = 1, [Descriptions("Items")]
		Items = 2,

		[Descriptions("Accounts")]
		Accounts = 3,
	}
}