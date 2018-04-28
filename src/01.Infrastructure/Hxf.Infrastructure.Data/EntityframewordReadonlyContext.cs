using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Hxf.Infrastructure.Data {
    public class EntityframewordReadonlyContext : DbContext, IEntityframeworkReadonlyContext {

        #region private variables

        //private readonly ILog _logger = LogManager.GetLogger(LogCategory.EntityFramework);

        #endregion

        #region constructor

        //public ObjectContext ObjectContext
        //{
        //    get { return ((IObjectContextAdapter)this).ObjectContext; }
        //}

        static EntityframewordReadonlyContext() {
            //Database.SetInitializer<EntityframewordReadonlyContext>(null);
        }

        protected EntityframewordReadonlyContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {
            //Database.Log = s => _logger.InfoFormat(s);
        }

        //public IQueryable<TReadModel> Table<TReadModel>() where TReadModel : class
        //{
        //    lock (_dbSetReadLock)
        //    {
        //        return Set<TReadModel>().AsNoTracking();
        //    }
        //}
        #endregion

        #region entity framework members

        //private EntityKey GetEntityKey<TEntity>(TEntity item) where TEntity : class
        //{
        //    var entitySetName = ObjectContext.CreateObjectSet<TEntity>().EntitySet.Name;
        //    return ObjectContext.CreateEntityKey(entitySetName, item);
        //}

        public new void Attach<TEntity>(TEntity item) where TEntity : class {
            if (item == null) {
                return;
            }

            Entry(item).State = EntityState.Unchanged;
        }

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class {
            return Set<TEntity>();
        }

        public IList<T> SqlQuery<T>(CommandType type, string sql, List<SqlParameter> parameters) where T : new() {
            var conn = Database.GetDbConnection();
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }

                using(var command = conn.CreateCommand()) {
                    command.CommandText = sql;
                    command.CommandType = type;
                    if (parameters != null && parameters.Count() > 0) {
                        foreach (var item in parameters) {
                            command.Parameters.Add(item);
                        }
                    }
                    var propts = typeof(T).GetProperties();
                    var rtnList = new List<T>();
                    T model;
                    object val;
                    using(var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            model = new T();
                            foreach (var l in propts) {
                                try {
                                    val = reader[l.Name];
                                    if (val == DBNull.Value) {
                                        l.SetValue(model, null);
                                    } else {
                                        l.SetValue(model, val);
                                    }
                                } catch (IndexOutOfRangeException) {
                                    continue;
                                }
                            }
                            rtnList.Add(model);
                        }
                    }
                    return rtnList;
                }
            } catch (Exception ex) {
                Log.Error(ex, "执行查询出错:{0}");
                return null;
            }
        }

        #endregion
        // public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlCommandText, params object[] parameters) where TEntity : new()
        // {
        //    return ObjectContext.ExecuteStoreQuery<TEntity>(sqlCommandText, parameters);
        // }

        //public int ExecuteNoQuery(string sqlCommmandText, params SqlParameter[] parameters)
        //{
        //    return ObjectContext.ExecuteStoreCommand(commandText: sqlCommmandText, parameters: parameters);
        //}

        //public object ExecuteScalar(string commandText, params SqlParameter[] parameters) {
        //    throw new System.NotImplementedException();
        //}
    }
}