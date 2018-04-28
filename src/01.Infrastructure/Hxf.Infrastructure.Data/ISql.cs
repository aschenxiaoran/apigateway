using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hxf.Infrastructure.Data
{
    public interface ISql
    {

        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlCommandText, params object[] parameters) where TEntity : new();

        int ExecuteNoQuery(string sqlCommmandText, params SqlParameter[] parameters);

        object ExecuteScalar(string commandText, params SqlParameter[] parameters);

    }
}