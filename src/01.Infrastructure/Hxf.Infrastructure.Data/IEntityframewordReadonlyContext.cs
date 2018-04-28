using System;
using Microsoft.EntityFrameworkCore;

namespace Hxf.Infrastructure.Data
{
    public interface IEntityframewordReadonlyContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    }
}