using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Hxf.Infrastructure.Extensions {
    public static class ReadNoLockExtensions {

        public static List<T> ToListNoLock<T>(this IQueryable<T> query) {

            using(var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions {IsolationLevel = IsolationLevel.ReadUncommitted})) {
                var toReturn = query.ToList();
                scope.Complete();
                return toReturn;
            }
        }

        

        public static int CountNoLock<T>(this IQueryable<T> query) {
            using(var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions {IsolationLevel = IsolationLevel.ReadUncommitted})) {
                var toReturn = query.Count();
                scope.Complete();
                return toReturn;
            }
        }

        public static TResult MaxNoLock<T, TResult>(this IQueryable<T> query, Expression<Func<T, TResult>> selector) {
            using(var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted })) {
                var toReturn = query.Max(selector);
                scope.Complete();
                return toReturn;
            }
        }
		

        public static int CountNoLock<TSource>(this IQueryable<TSource> query, Expression<Func<TSource, bool>> predicate) {
            using(var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions {IsolationLevel = IsolationLevel.ReadUncommitted})) {
                var toReturn = query.Count(predicate);
                scope.Complete();
                return toReturn;
            }
        }




        public static TSource FirstOrDefaultNoLock<TSource>(this IQueryable<TSource> query) {
            using(var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions {IsolationLevel = IsolationLevel.ReadUncommitted})) {
                var toReturn = query.FirstOrDefault();
                scope.Complete();
                return toReturn;
            }
        }


        public static bool AnyNoLock<TSource>(this IQueryable<TSource> query, Expression<Func<TSource, bool>> predicate) {
            using(var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions {IsolationLevel = IsolationLevel.ReadUncommitted})) {
                var toReturn = query.Any(predicate);
                scope.Complete();
                return toReturn;
            }
        }

        public static List<T> ToNoLockList<T>(this IQueryable<T> query)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                List<T> toReturn = query.ToList();
                scope.Complete();
                return toReturn;
            }
        }
    }
}