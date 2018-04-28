using FluentValidation.Validators;
using Hxf.Infrastructure.Validation.Validators;

namespace Hxf.Infrastructure.Validation
{
	public static class FluentValidatorExtensions
	{
		public static FluentValidation.IRuleBuilderOptions<T, TProperty> StringMatches<T, TProperty>(this FluentValidation.IRuleBuilder<T, TProperty> ruleBuilder, string expression)
		{
			if (typeof(TProperty) == typeof(string))
			{
				return ruleBuilder.SetValidator(new RegularExpressionValidator(expression));
			}
			return ruleBuilder.SetValidator(new ObjectRegularExpressionValidator(expression));
		}
		public static FluentValidation.IRuleBuilderOptions<T, TProperty> StringContainsWhiteSpace<T, TProperty>(this FluentValidation.IRuleBuilder<T, TProperty> ruleBuilder)
		{
			return ruleBuilder.SetValidator(new StringContainsWhiteSpaceValidator());
		}
	}
}
