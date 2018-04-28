using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.EntityFrameworkCore;

namespace Hxf.Infrastructure.Data {
    public class EntityframeworkContext : EntityframewordReadonlyContext, IUnitOfWork, IEntityframeworkContext {

        #region constructor

        //private readonly ILog _logger = LogManager.GetLogger(LogCategory.Error, typeof(EntityframeworkContext));

        static EntityframeworkContext() {
            //Database.SetInitializer<EntityframeworkContext>(null);

        }
        //protected EntityframeworkContext()
        //{
        //}

        protected EntityframeworkContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {
            //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.ValidateOnSaveEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;

            //ExecuteScalar("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");//防止sql死锁
        }

        #endregion

        #region entity framework members

        public virtual void SetAdded<TEntity>(TEntity entity) where TEntity : class {
            if (entity == null) {
                return;
            }
            Entry(entity).State = EntityState.Added;
        }

        public virtual void SetModified<TEntity>(TEntity entity) where TEntity : class {
            if (entity == null) {
                return;
            }
            Entry(entity).State = EntityState.Modified;

        }

        public virtual void SetAddedOrModified<TEntity>(TEntity entity, Func<TEntity, bool> isAttachedFunc) where TEntity : class {
            if (entity == null)
                return;

            if (Set<TEntity>().Local.Any(isAttachedFunc)) {
                Entry(entity).State = EntityState.Modified;
                return;
            }

            Entry(entity).State = EntityState.Added;
        }

        public void SetModified<TEntity, TResult>(TEntity item, Expression<Func<TEntity, TResult>> properties) where TEntity : class {
            if (item == null) {
                return;
            }

            Entry(item).State = EntityState.Modified;
            //var stateManager = ObjectContext.ObjectStateManager;
            //ObjectStateEntry stateEntry;

            //var entityKey = GetEntityKey(item);
            //if (stateManager.TryGetObjectStateEntry(entityKey, out stateEntry))
            //{
            //    Entry(stateEntry.Entity).State = EntityState.Detached;
            //}

            //Attach(item);

            //var propertyNames = properties.Name;
            //foreach (var propertyName in propertyNames)
            //{
            //    if (!string.IsNullOrWhiteSpace(propertyName))
            //    {
            //        Entry(item).Property(propertyName).IsModified = true;
            //    }
            //}
        }

        //private EntityKey GetEntityKey<TEntity>(TEntity item) where TEntity : class
        //{
        //    var entitySetName = ObjectContext.CreateObjectSet<TEntity>().EntitySet.Name;
        //    return ObjectContext.CreateEntityKey(entitySetName, item);
        //}

        public void SetRemoved<TEntity>(TEntity entity) where TEntity : class {
            if (entity == null) {
                return;
            }
            Entry(entity).State = EntityState.Deleted;
        }

        public Task AddRangeAsync<TEntity>(IList<TEntity> entityList) where TEntity : class {
            return base.AddRangeAsync(entityList);
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class {
            return base.Set<TEntity>();
        }

        #endregion

        #region IUnitWork Members

        public void Commit([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "") {
            // try
            // {
            SaveChanges();
            // }
            // catch (DbUpdateConcurrencyException dbEx)
            // {
            //     var msg = new StringBuilder();

            //     foreach (var entry in dbEx.Entries)
            //     {
            //         msg.AppendFormat("Entry: {0}\n", entry);
            //     }
            //     //_logger.DebugFormat("an error raised when commit: {0}{1}\n", dbEx, msg);

            // }
            // //catch (DbEntityValidationException dbEx)
            // //{
            // //    var msg = new StringBuilder();

            // //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            // //    {
            // //        foreach (var validationError in validationErrors.ValidationErrors)
            // //        {
            // //            msg.AppendFormat("Validation error: {0} Error: {1}\n", validationError.PropertyName,
            // //                validationError.ErrorMessage);
            // //        }
            // //    }
            // //    var fail = new Exception(msg.ToString(), dbEx);
            // //    _logger.Debug(msg, fail);

            // //    throw fail;
            // //}
            // catch (Exception ex)
            // {
            //     //_logger.Debug("an error raised when commit.", ex);

            //     throw ex;
            // }
            // finally
            // {
            //     //Dispose();
            // }
        }

        public async Task CommitAsync([CallerMemberName] string memberName = "") {
            // try {
            await SaveChangesAsync();
            // } catch (DbUpdateConcurrencyException dbEx) {
            //     var msg = new StringBuilder ();

            //     foreach (var entry in dbEx.Entries) {
            //         msg.AppendFormat ("Entry: {0}\n", entry);
            //     }
            //     //_logger.DebugFormat("an error raised when commit: {0}\n", dbEx, msg);
            // }
            // //catch (DbEntityValidationException dbEx)
            // //{
            // //    var msg = new StringBuilder();

            // //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            // //    {
            // //        foreach (var validationError in validationErrors.ValidationErrors)
            // //        {
            // //            msg.AppendFormat("Validation error: {0} Error: {1}\n", validationError.PropertyName,
            // //                validationError.ErrorMessage);
            // //        }
            // //    }
            // //    var fail = new Exception(msg.ToString(), dbEx);
            // //    _logger.Debug(msg, fail);

            // //    throw fail;
            // //}
            // catch (Exception ex) {
            //     //_logger.Error("an error raised when commit.", ex);
            //     throw ex;
            // }
        }

        public void Rollback([CallerMemberName] string memberName = "") {
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        #region ISql Members

        public int ExecuteSync(string sql, IEnumerable<DbParameter> parameters) {
            object[]
            @params;
            if (parameters != null) {
                @params = parameters.Select(p => (object)p).ToArray();
            }
            else {
                @params = new object[0];
            }

            return Database.ExecuteSqlCommand(sql, @params);

        }

        #endregion

    }

    internal class NavigationAttribute {
    }
}