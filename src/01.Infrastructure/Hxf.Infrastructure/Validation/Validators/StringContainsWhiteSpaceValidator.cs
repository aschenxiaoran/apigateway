using System.Linq;
using FluentValidation.Validators;
using Hxf.Infrastructure.Extensions;

namespace Hxf.Infrastructure.Validation.Validators {
    public class StringContainsWhiteSpaceValidator : PropertyValidator {
        public StringContainsWhiteSpaceValidator() : base("Property {PropertyName} contains whitespace!") {

        }

        protected override bool IsValid(PropertyValidatorContext context) {
            var value = context.PropertyValue as string;
            return !value.EnsureNotNull().EnsureTrim().Any(char.IsWhiteSpace);
        }
    }
}