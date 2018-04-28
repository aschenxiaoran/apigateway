namespace Hxf.Infrastructure.Data {
    public interface IEntityframeworkContext : IEntityframeworkReadonlyContext, IUnitOfWork {
        //void SetAdded<TEntity>(TEntity entity) where TEntity : class;
        //void SetModified<TEntity>(TEntity entity) where TEntity : class;
        //void SetModified<TEntity>(Expression<Func<TEntity, bool>> filter);

        //void SetModified<TEntity, TResult>(TEntity item, Expression<Func<TEntity, TResult>> properties)
        //	where TEntity : class;
        //void SetRemoved<TEntity>(TEntity entity) where TEntity : class;

        //DbSet<TEntity> Set<TEntity>() where TEntity : class;

        //DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

    }
}