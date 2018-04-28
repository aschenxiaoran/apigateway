using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.Exceptions {
    public class UserInputErrorException : DomainException {
        public UserInputErrorException() {

        }

        public UserInputErrorException(params ValidationErrorItem[] errorItem) {
            ValidationErrors.AddErrors(errorItem);
        }

        public UserInputErrorException(IValidationErrors errors)
            : base(errors) {

        }
    }
}