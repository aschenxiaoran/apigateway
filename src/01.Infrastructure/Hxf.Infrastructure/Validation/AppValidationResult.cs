using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FluentValidation.Results;

namespace Hxf.Infrastructure.Validation {

	/// <summary>
	/// 程序域验证结果
	/// </summary>
	[DataContract]
	public class AppValidationResult {
		
		[DataMember]
		public bool IsValid { get; set; }

		[DataMember]
		public IList<ValidationFailure> Errors { get; set; }

		private string _errorMessages;

		[DataMember]
		public string ErrorMessages {
			get {
				var errors = new StringBuilder();

				var firstOrDefault = Errors.FirstOrDefault();
				if (firstOrDefault != null)
					errors.Append(firstOrDefault.ErrorMessage + Environment.NewLine);

				_errorMessages = errors.ToString();
				return _errorMessages;
			}
			set { _errorMessages = value; }
		}
	}
}