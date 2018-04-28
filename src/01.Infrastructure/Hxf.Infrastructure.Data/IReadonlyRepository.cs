using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Hxf.Infrastructure.Data{
    public interface IReadonlyRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        bool Exsits(Func<TEntity, bool> predicate, [CallerMemberName] string memberName = "");

        TEntity GetById(int id);

        TEntity Get(Expression<Func<TEntity, bool>> predicate, [CallerMemberName] string memberName = "");

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);
    }
}