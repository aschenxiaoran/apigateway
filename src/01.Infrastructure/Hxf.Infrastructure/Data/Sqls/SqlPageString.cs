namespace Hxf.Infrastructure.Data.Sqls
{
	public class SqlPageString {
		#region ∑÷“≥Sql

		public static string PageSqlString = @"SELECT *
                                                FROM
                                                (
                                                {0}
                                                )com
                                                WHERE RowNum BETWEEN ({1}-1)*{2}+1 AND {1}*{2}";

		#endregion
	}
}