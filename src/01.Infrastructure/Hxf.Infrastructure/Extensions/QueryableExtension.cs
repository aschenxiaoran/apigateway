using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Extensions {
    public static class QueryableExtension {
        public static IQueryable<TSource> ToPaginated<TSource>(this IQueryable<TSource> sources, Pagination paginated) {
            if (sources == null) {
                throw new ArgumentNullException("sources");
            }

            return sources.Skip(paginated.SkipCount).Take(paginated.PageSize);
        }

        public static Expression<Func<T, bool>> BuildExpression<T>(this PageQueryDto queryDto) {
            var type = queryDto.GetType();
            var querypropertys = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var Parameter = Expression.Parameter(typeof(T));
            BinaryExpression condition = Expression.GreaterThan(Expression.Constant(1), Expression.Constant(0));
            foreach (var q in querypropertys) {
                var value = q.GetValue(queryDto);
                //DTO类型
                var entityproperty = typeof(T).GetProperty(q.Name);
                var attribute = q.GetCustomAttribute<DisplayNameAttribute>();
                if (value == null || (entityproperty == null && (attribute == null || typeof(T).GetProperty(attribute.DisplayName) == null))) { continue; }
                if (attribute != null && attribute.DisplayName == "Ignore") { continue; }
                object resultvalue;
                var tp = q.PropertyType;
                if (tp.IsGenericType && tp.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) {
                    NullableConverter nullableConverter = new NullableConverter(tp);
                    if (nullableConverter.UnderlyingType.BaseType == typeof(Enum)) {
                        //枚举类型转换
                        resultvalue = Enum.Parse(nullableConverter.UnderlyingType, value.ToString(), false);
                    } else {
                        //非枚举类型装换
                        resultvalue = Convert.ChangeType(value, nullableConverter.UnderlyingType);
                    }
                    tp = nullableConverter.UnderlyingType;
                } else {
                    resultvalue = Convert.ChangeType(value, tp);
                }
                if (tp == typeof(int) && (int) resultvalue > 0) {
                    condition = Expression.And(condition,
                        Expression.Equal(Expression.Convert(Expression.Property(Parameter, q.Name), typeof(int)),
                            Expression.Constant(resultvalue)));
                } else if (tp == typeof(long) && (long) resultvalue > 0)
                    condition = Expression.And(condition,
                        Expression.Equal(Expression.Convert(Expression.Property(Parameter, q.Name), typeof(long)),
                            Expression.Constant(resultvalue)));
                else if (tp == typeof(decimal) && (decimal) resultvalue > 0) {
                    condition = Expression.And(condition,
                        Expression.Equal(Expression.Convert(Expression.Property(Parameter, q.Name), typeof(decimal)),
                            Expression.Constant(resultvalue)));
                } else if (tp == typeof(bool)) {
                    condition = Expression.And(condition,
                        Expression.Equal(Expression.Convert(Expression.Property(Parameter, q.Name), typeof(bool)),
                            Expression.Constant(resultvalue)));
                } else if (tp.BaseType == typeof(Enum) && (int) resultvalue >= 0) {
                    var right = Expression.Convert(Expression.Property(Parameter, q.Name), tp);
                    condition = Expression.And(condition,
                        Expression.Equal(right,
                            Expression.Constant(resultvalue)));
                } else if (tp == typeof(string) && !string.IsNullOrWhiteSpace(resultvalue.ToString())) {
                    var containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                    condition = Expression.And(condition,
                        Expression.Call(Expression.Property(Parameter, q.Name), containsMethod,
                            Expression.Constant(resultvalue)));
                } else if (typeof(IList).IsAssignableFrom(tp)) {
                    var containsMethod = tp.GetMethod("Contains", new Type[] { tp.GetGenericArguments() [0] });
                    condition = Expression.And(condition,
                        Expression.Call(Expression.Constant(resultvalue), containsMethod,
                            Expression.Property(Parameter, attribute.DisplayName)));
                }
            }
            var lambda = Expression.Lambda<Func<T, bool>>(condition, Parameter);
            return lambda;
        }

        public static PageQueryDto QueryConvert(this PageQueryDto source) {
            var pro = source.GetType().GetProperty(source.SelectedType, BindingFlags.Public | BindingFlags.Instance);
            if (pro == null) return source;
            if (string.IsNullOrWhiteSpace(source.SelectedValue)) {
                return source;
            }
            var value = Convert.ChangeType(source.SelectedValue, pro.PropertyType);
            pro.SetValue(source, value);
            return source;
        }
    }
}