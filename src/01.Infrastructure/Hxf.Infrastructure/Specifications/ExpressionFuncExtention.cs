using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Hxf.Infrastructure.Extensions;

namespace Hxf.Infrastructure.Specifications {
    public static class ExpressionFuncExtention {

        #region Private Methods

        private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge) {

            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);


            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);


            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }
        #endregion

        #region Public Methods

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, string key) {
            return key.IsNullOrWhiteSpace() ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, bool? key) {
            return key == null ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, bool key) {
            return And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, int? key) {
            return key == null ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, int key) {
            return And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, long? key) {
            return key == null ? first : And(first, second);
        }
        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, DateTime? key) {
            return key == null ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, long key) {
            return key.Equals(default(T)) ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, decimal? key) {
            return key == null ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, decimal key) {
            return key.Equals(default(T)) ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, IList<int> key) {
            return (key==null || key.Count==0) ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, IList<string> key) {
            return (key==null || key.Count==0) ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, IQueryable<int> key) {
            return (key==null || key.Count()==0) ? first : And(first, second);
        }

        public static Expression<Func<T, bool>> AndTime<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) {
            var binaryExp = second.Body as BinaryExpression;
            var memberExpression = binaryExp.Left as MemberExpression;

            if (memberExpression == null) {
                return first;
            }

            Expression constantExp = memberExpression.Expression == second.Parameters[0] ? binaryExp.Right : binaryExp.Left;
            object secondExpressionValue = Expression.Lambda(constantExp).Compile().DynamicInvoke();

            if (secondExpressionValue == null) {
                return first;
            }

            return And(first, second);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) {
            return first.Compose(second, Expression.Or);
        }
        public static Expression<Func<T, bool>> OrNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second,string key) {
            return key.IsNullOrWhiteSpace() ? first: first.Compose(second, Expression.Or);
        }

        public static Expression<Func<T, bool>> OrNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second,int? key) {
            return key==null ? first: first.Compose(second, Expression.Or);
        }

        public static Expression<Func<T, bool>> OrNotNull<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, IList<int> key) {
            return (key==null || key.Count==0) ? first : first.Compose(second, Expression.Or);
        }
        #endregion
    }
}
