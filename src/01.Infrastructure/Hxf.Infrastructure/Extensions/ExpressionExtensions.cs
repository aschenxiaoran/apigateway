using System;
using System.Linq.Expressions;

namespace Hxf.Infrastructure.Extensions
{
    public static class ExpressionExtensions {
        public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty>> expression) {
            var propertyName = "";
            if (expression.Body is UnaryExpression) {
                propertyName = ((MemberExpression)((UnaryExpression)expression.Body).Operand).Member.Name;
            }
            else if (expression.Body is MemberExpression) {
                propertyName = ((MemberExpression)expression.Body).Member.Name;
            }
            else if (expression.Body is ParameterExpression) {
                propertyName = ((ParameterExpression)expression.Body).Type.Name;
            }
            return propertyName;

        }

    }
}