using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Hxf.Infrastructure.Extensions {
    public static class PropertySupport {
        public static string ExtractPropertyName(this LambdaExpression expression) {
            if (expression == null) {
                return null;
            }

            var bodyExpression = expression.Body;
            if (bodyExpression.NodeType == ExpressionType.Convert) {
                bodyExpression = ExtractMemberExpression(bodyExpression as UnaryExpression);
            }

            if (bodyExpression.NodeType == ExpressionType.MemberAccess) {
                var name = ExtractPropertyName(bodyExpression as MemberExpression);
                return name;
            }

            return null;
        }

        public static string[] ExtractPropertyNames(this LambdaExpression expression) {
            var result = new List<string>();

            if (expression == null) {
                return result.ToArray();
            }

            var bodyExpression = expression.Body;
            if (bodyExpression.NodeType == ExpressionType.New) {
                var newExpression = (NewExpression)bodyExpression;
                result.AddRange(newExpression.Members.Select(property => property.Name));
                return result.ToArray();
            }

            var name = ExtractPropertyName(expression);
            result.Add(name);

            return result.ToArray();
        }

        private static string ExtractPropertyName(MemberExpression memberExpression) {
            if (memberExpression == null) {
                return null;
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null) {
                return null;
            }

            var getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic) {
                return null;
            }

            return memberExpression.Member.Name;
        }

        private static MemberExpression ExtractMemberExpression(UnaryExpression convertExpression) {
            if (convertExpression == null) {
                return null;
            }

            if (convertExpression.NodeType != ExpressionType.Convert) {
                return null;
            }

            return convertExpression.Operand as MemberExpression;
        }

    }
}
