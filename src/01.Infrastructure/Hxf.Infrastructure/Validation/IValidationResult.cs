using System.Collections.Generic;

namespace Hxf.Infrastructure.Validation {

	public interface IValidationErrors {
		
		IValidationErrors AddErrors(IEnumerable<ValidationErrorItem> errorItems);

		IValidationErrors AddError(string propertyName, string errorMessage, object attemptedValue, bool customState=false);
		IValidationErrors AddSystemError(string propertyName = "SystemError", string errorMessage = "网络错误",
			object attemptedValue = null, bool customState = false);

		/// <summary>
		/// 结果是否正确
		/// </summary>
		bool IsValid { get; }

		IEnumerable<ValidationErrorItem> ErrorItems { get; }
	}
}
