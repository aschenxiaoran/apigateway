using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Hxf.Infrastructure.Extensions;

namespace Hxf.Infrastructure.Utilities {

	/// <summary>
	/// 表达式树查询条件工具类
	/// </summary>
	public class WhereExpressionUtility {

		public readonly static WhereExpressionUtility Instance = new WhereExpressionUtility();

		private WhereExpressionUtility() {

		}

		public Expression<Func<TQuerySource, bool>> CreateWhereExpression<TQuerySource, TQueryCondition>(TQueryCondition queryCondition)
			where TQuerySource : class
			where TQueryCondition : class {

			var exprList = new List<Expression>();
			ParameterExpression paramExpr = Expression.Parameter(typeof(TQuerySource), "m");

			var querySourceAttributes = queryCondition.GetType().GetProperties();

			foreach (PropertyInfo propertyInfo in querySourceAttributes) {
				dynamic propertyValue = GetPropertyValue(propertyInfo.Name, propertyInfo.PropertyType, queryCondition);
				object[] filterMemberAttributes = propertyInfo.GetCustomAttributes(typeof(FilterMemberAttribute), true);

				if (IsFilterMemberAttributeValid<TQuerySource, TQueryCondition>(filterMemberAttributes, propertyValue)) {

					var filterAttribute = (FilterMemberAttribute)filterMemberAttributes[0];
					var columnName = filterAttribute.ColumnName ?? propertyInfo.Name;
					var filterKeyType = filterAttribute.Type;//查询关键字类型contain,equal

					var notFilterValue = filterAttribute.NotFilterValue;
					var notFilterResult = filterAttribute.NotFilterResult;

					if (!notFilterResult.Contains(propertyValue.ToString()) || notFilterValue == null) {
						switch (filterKeyType) {
							case FilterType.Contains:
								var nameContainsExpr = CreateContainsExpression<TQuerySource, TQueryCondition>(paramExpr, columnName, propertyValue, propertyInfo);
								exprList.Add(nameContainsExpr);
								break;

							case FilterType.Equal:
								var groupExpr = CreateEqualExpression<TQuerySource, TQueryCondition>(paramExpr, columnName, propertyValue, propertyInfo);
								exprList.Add(groupExpr);

								break;

							case FilterType.GreaterThanOrEqual:
								var greaterThanOrEqual = CrateGreaterThanOrEqualExpression<TQuerySource, TQueryCondition>(paramExpr, columnName, propertyValue, propertyInfo);
								exprList.Add(greaterThanOrEqual);
								break;

							case FilterType.LessThanOrEqual:
								var lessThanOrEqual = CreateLessThanOrEqualExpression<TQuerySource, TQueryCondition>(paramExpr, columnName, propertyValue, propertyInfo);
								exprList.Add(lessThanOrEqual);
								break;
						}

					}
				}
			}

			Expression<Func<TQuerySource, bool>> lambda = CreateLambdaExpression<TQuerySource>(exprList, paramExpr);
			return lambda;
		}

		#region private methods

		private static dynamic IsFilterMemberAttributeValid<TQuerySource, TQueryCondition>(object[] filterMemberAttributes, dynamic propertyValue)
			where TQuerySource : class
			where TQueryCondition : class {
			return filterMemberAttributes.Length > 0 && (propertyValue != null && !string.IsNullOrWhiteSpace(propertyValue.ToString()));
		}

		#region create expression 

		private static BinaryExpression CreateLessThanOrEqualExpression<TQuerySource, TQueryCondition>(
			ParameterExpression paramExpr, string columnName, dynamic propertyValue, PropertyInfo propertyInfo)
			where TQuerySource : class
			where TQueryCondition : class {
			MemberExpression propertyExpression = Expression.Property(paramExpr, columnName);
			ConstantExpression nameValueExpr = Expression.Constant(propertyValue, propertyInfo.PropertyType);
			BinaryExpression lessThanOrEqual = Expression.LessThanOrEqual(propertyExpression, nameValueExpr);
			return lessThanOrEqual;
		}

		private static BinaryExpression CrateGreaterThanOrEqualExpression<TQuerySource, TQueryCondition>(
			ParameterExpression paramExpr, string columnName, dynamic propertyValue, PropertyInfo propertyInfo)
			where TQuerySource : class
			where TQueryCondition : class {
			MemberExpression propertyExpression = Expression.Property(paramExpr, columnName);
			ConstantExpression nameValueExpr = Expression.Constant(propertyValue, propertyInfo.PropertyType);
			BinaryExpression greaterThanOrEqual = Expression.GreaterThanOrEqual(propertyExpression, nameValueExpr);
			return greaterThanOrEqual;
		}

		private static BinaryExpression CreateEqualExpression<TQuerySource, TQueryCondition>(ParameterExpression paramExpr,
			string columnName, dynamic propertyValue, PropertyInfo propertyInfo)
			where TQuerySource : class
			where TQueryCondition : class {
			MemberExpression propertyExpression = Expression.Property(paramExpr, columnName);
			ConstantExpression valueExpression = Expression.Constant(propertyValue, propertyInfo.PropertyType);
			BinaryExpression groupExpr = Expression.Equal(propertyExpression, valueExpression);
			return groupExpr;
		}

		private static MethodCallExpression CreateContainsExpression<TQuerySource, TQueryCondition>(ParameterExpression paramExpr,
			string columnName, dynamic propertyValue, PropertyInfo propertyInfo)
			where TQuerySource : class
			where TQueryCondition : class {
			MemberExpression namePropExpr = Expression.Property(paramExpr, columnName);
			MethodInfo containsMethod = typeof(string).GetMethod("Contains");
			ConstantExpression nameValueExpr = Expression.Constant(propertyValue, propertyInfo.PropertyType);
			MethodCallExpression nameContainsExpr = Expression.Call(namePropExpr, containsMethod, nameValueExpr);
			return nameContainsExpr;
		}

		private static Expression<Func<TQuerySource, bool>> CreateLambdaExpression<TQuerySource>(List<Expression> exprList, ParameterExpression paramExpr) where TQuerySource : class {
			Expression whereExpr = null;

			foreach (var expr in exprList) {
				whereExpr = whereExpr == null ? expr : Expression.And(whereExpr, expr);
			}

			Expression<Func<TQuerySource, bool>> lambda = whereExpr != null ? Expression.Lambda<Func<TQuerySource, bool>>(whereExpr, paramExpr) : null;

			return lambda;
		}

		#endregion

		#region get property dynamic value

		private dynamic GetPropertyDynamicValue(Type propertyType, string propertyValue) {
			if (propertyType == typeof(int)) {
				return Convert.ToInt32(propertyValue);
			}
			if (propertyType == typeof(bool)) {
				return Convert.ToBoolean(propertyValue);
			}
			if (propertyType == typeof(decimal)) {
				return Convert.ToDecimal(propertyValue);
			}
			if (propertyType == typeof(string)) {
				return propertyValue;
			}
			if (propertyType == typeof(DateTime)) {
				return Convert.ToDateTime(propertyValue);
			}
			if (propertyType == typeof(DateTime?)) {
				return propertyValue.ToDateTime();
			}

			return propertyValue;
		}

		private dynamic GetPropertyValue(string propertyName, Type propertyType, object obj) {
			try {
				Type type = obj.GetType();
				object value1 = type.GetProperty(propertyName).GetValue(obj, null);
				string value = Convert.ToString(value1);
				dynamic result = GetPropertyDynamicValue(propertyType, value);

				return result;
			}
			catch {
				return null;
			}
		}

		#endregion

		#endregion
	}


	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public class FilterMemberAttribute : Attribute {
		/// <summary>
		/// 表名
		/// </summary>
		public string TableShortName { get; set; }

		/// <summary>
		/// 列名
		/// </summary>
		public string ColumnName { get; set; }

		/// <summary>
		/// 查询类型（AND,OR,LIKE）
		/// </summary>
		public FilterType Type { get; set; }

		/// <summary>
		/// 不查询的默认值
		/// </summary>
		public string NotFilterValue { get; set; }

		public List<string> NotFilterResult {
			get {
				var result = new List<string>();
				if (!NotFilterValue.IsNullOrWhiteSpace()) {
					var splits = NotFilterValue.Split(',');
					result = splits.ToArray().ToList();
				}
				return result;
			}
		}
	}

	public enum FilterType {
		[Description("Contain")]
		Contains = 1,
		[Description("=")]
		Equal = 2,
		[Description(">=")]
		GreaterThanOrEqual = 3,
		[Description("<=")]
		LessThanOrEqual = 4
	}
}
