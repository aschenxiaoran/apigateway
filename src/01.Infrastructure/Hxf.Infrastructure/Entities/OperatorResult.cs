using System;
using System.Text;
using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.Entities {
	[Serializable]
	public class OperatorResult {

		public IValidationErrors Errors { get; set; }

		public bool IsValid {
			get {
				return Errors.IsValid;
			}
		}

		public string ErrorProperty { get; set; }

		public OperatorResult() {
			Errors = new ValidationErrors();
		}

		public string ResultKey { get; set; }

		public string ErrorMessage {
			get {
				var errorMessage = new StringBuilder();
				foreach (ValidationErrorItem errorItem in Errors.ErrorItems) {
					errorMessage.Append(errorItem.ErrorMessage);
				}
				return errorMessage.ToString();
			}
		}
	}
}