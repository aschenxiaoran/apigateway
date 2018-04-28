using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Hxf.Infrastructure.Data {
    public class ReadonlyRepository<TEntity> : IReadonlyRepository<TEntity> where TEntity : class, IAggregateRoot {

        #region private varialbes

        private IEntityframeworkReadonlyContext _unitWork;
        private readonly object _locker = new object();

        public DbSet<TEntity> Entities => _unitWork.CreateSet<TEntity>();

        #endregion

        #region ctor

        public ReadonlyRepository(IEntityframeworkReadonlyContext unitWork) {
            _unitWork = unitWork;
        }

        #endregion

        #region queries

        public bool Exsits(Func<TEntity, bool> predicate, string memberName = "") {
            return Entities.Local.Any(predicate);
        }

        public TEntity GetById(int id) {
            return Entities.Find(id);
        }

        public TEntity GetById(long id) {
            return Entities.Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {

            TEntity entity = Entities.FirstOrDefault(predicate: predicate);
            return entity;

        }

        public TEntity GetAsNoTracking(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {
            var entity = Entities.AsNoTracking().FirstOrDefault(predicate: predicate);
            return entity;
        }

        public async Task<TEntity> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {
            var entity = await Entities.AsNoTracking().FirstOrDefaultAsync(predicate: predicate);
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {

            return await Entities.FirstOrDefaultAsync(predicate: predicate);
        }

        public IQueryable<TEntity> GetAll([CallerMemberName] string memberName = "") {
            return Entities;
        }

        public IQueryable<TEntity> GetAllAsNoTracking([CallerMemberName] string memberName = "") {
            return Entities.AsNoTracking();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {
            var enityList = Entities.Where(predicate);
            return enityList;
        }

        public IQueryable<TEntity> GetAllAsNoTracking(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {

            var enityList = Entities.AsNoTracking().Where(predicate);

            return enityList;

        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {

            var entityCount = await Entities.CountAsync(predicate);
            return entityCount;
        }

        public async Task<int> CountAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "") {

            var entityCount = await Entities.AsNoTracking().CountAsync(predicate);
            return entityCount;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity>> orderByExpression, [CallerMemberName] string memberName = "") {
            return Entities.Where(predicate);
        }

        public IQueryable<TEntity> GetAll<TSource, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> orderByExpression) {
            return Entities.Where(predicate).OrderBy(orderByExpression);
        }

        public IQueryable<TEntity> GetAllAsNoTracking(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize) {
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            return Entities.AsNoTracking().Where(predicate).Skip(skip).Take(take);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize) {
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            return Entities.Where(predicate).Skip(skip).Take(take);
        }

        //public Task<int> CountNoLockAsync<T>(IQueryable<T> query) {
        //    using (var scope = TransactionFactory.Required(IsolationLevel.ReadUncommitted)) {
        //        var toReturn = Entities.CountAsync();
        //        scope.Complete();
        //        return toReturn;
        //    }
        //}

        public DbSet<TEntity> GetSet() {
            return _unitWork.CreateSet<TEntity>();
        }

        public IQueryable<TReadModel> Table<TReadModel>() where TReadModel : class {

            return _unitWork.Set<TReadModel>().AsNoTracking();

        }

        #endregion

        #region dispose

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                if (_unitWork != null) {
                    _unitWork.Dispose();

                    _unitWork = null;
                }
            }
        }

        #endregion
    }
}