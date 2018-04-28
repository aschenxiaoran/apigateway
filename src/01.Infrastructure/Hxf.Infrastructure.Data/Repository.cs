using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Hxf.Infrastructure.Data
{
    public class Repository<TEntity> : ReadonlyRepository<TEntity>, IRepository<TEntity> where TEntity : class, IAggregateRoot
    {

        #region private varialbes

        private EntityframeworkContext _unitWork;
                  

        #endregion

        #region ctor

        public Repository(IEntityframeworkContext unitWork) : base(unitWork)
        {
            _unitWork = (EntityframeworkContext)unitWork;
        }

        #endregion

        #region Operators
                
        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            _unitWork.SetAdded(entity);
            return entity;
        }

        public Task AddRange(IList<TEntity> entityList) {
            return _unitWork.AddRangeAsync(entityList);
        }

        public TEntity Modify(TEntity entity)
        {
            _unitWork.SetModified(entity: entity);
            return entity;
        }

        public virtual void Modify<TResult>(TEntity entity, Expression<Func<TEntity, TResult>> properties)
        {
            if (entity == null)
            {
                return;
            }

            _unitWork.SetModified(entity, properties);
        }

        public virtual int Modify(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            return Entities.Where(filterExpression).Update(updateExpression);
        }

        public virtual async Task<int> ModifyAsync(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            return await Entities.Where(filterExpression).UpdateAsync(updateExpression);
        }

        // public virtual TEntity AddOrModify(TEntity entity)
        // {
        //     return entity.Id == 0
        //         ? Add(entity)
        //         : Modify(entity);
        // }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            _unitWork.SetRemoved(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            await Task.FromResult(Entities.Remove(entity));
        }

        //public async Task BatchRemoveAsync(Expression<Func<TEntity, bool>> predicate) {
        //    if (predicate == null) {
        //        return;
        //    }
        //    await Task.FromResult(Entities.Where(predicate).Delete());
        //}

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="predicate"></param>
        public int BatchRemove(Expression<Func<TEntity, bool>> predicate)
        {
            var deleteEntities = Entities.Where(predicate);

            if (deleteEntities.Any()) {
                return deleteEntities.Delete();
            }

            return 0;
        }

        public async Task<int> BatchRemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var deleteEntities = Entities.Where(predicate);

            if (deleteEntities.Any())
            {
                return await deleteEntities.DeleteAsync();
            }

            return 0;
        }

        public async Task<int> BatchModifyAsync(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            var modifyEntities = Entities.Where(filterExpression);

            if (modifyEntities.Any()) {
                return await modifyEntities.UpdateAsync(updateExpression);
            }

            return 0;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="entity"></param>
        /// <param name="filterExpression"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public virtual int BatchModify<TResult>(TEntity entity, Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            var modifyEntities = Entities.Where(filterExpression);

            if (modifyEntities.Any()) {
                return modifyEntities.Update(updateExpression);
            }

            return 0;
        }
      

        #endregion

        #region dispose

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_unitWork != null)
                {
                    _unitWork.Dispose();

                    _unitWork = null;
                }
            }
        }

        #endregion
    }

}
