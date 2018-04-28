using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hxf.Infrastructure.Data {
    public interface IEntityframeworkReadonlyContext : IDisposable {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        IList<T> SqlQuery<T>(CommandType type, string sql, List<SqlParameter> parameters) where T : new();
    }
}