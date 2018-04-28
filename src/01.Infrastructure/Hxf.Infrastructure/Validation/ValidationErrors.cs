using System;
using System.Collections.Generic;

namespace Hxf.Infrastructure.Validation {
    [Serializable]
    public class ValidationErrors : IValidationErrors {

        private readonly List<ValidationErrorItem> _errorItemList = new List<ValidationErrorItem>();

        public bool IsValid => _errorItemList.Count == 0;

        public IEnumerable<ValidationErrorItem> ErrorItems { get { return _errorItemList; } }

        public IValidationErrors AddSystemError(string propertyName = "SystemError", string errorMessage = "系统错误",
            object attemptedValue = null, bool customState = false) {
            return AddError(propertyName, errorMessage, attemptedValue, customState);
        }

        public IValidationErrors AddErrors(IEnumerable<ValidationErrorItem> errorItems) {
            if (errorItems == null) {
                return this;
            }
            foreach (var errorItem in errorItems) {
                if (errorItem.CustomState) {
                    errorItem.PropertyName = ErrorMessage.IsAlter;
                }
                _errorItemList.Add(errorItem);
            }

            return this;
        }
        public IValidationErrors AddError(string propertyName, object attemptedValue, string errorMessage = null, bool customState = false,string validateKey="") {
            var errorItem = new ValidationErrorItem(propertyName, errorMessage, attemptedValue, customState,validateKey);
            _errorItemList.Add(errorItem);
            return this;
        }

        public IValidationErrors AddError(string propertyName, string errorMessage, object attemptedValue, bool customState=false) {
            var errorItem = new ValidationErrorItem(propertyName, errorMessage, attemptedValue, customState);
            _errorItemList.Add(errorItem);
            return this;
        }
    }
}