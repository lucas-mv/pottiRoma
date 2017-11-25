using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.DataAccess.Core
{
    public abstract class BaseDataAccess<TEntity, TQuery>
    {
        private IDbConnection GetDbConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["PottiRomaConnectionString"]);
        }

        protected IEnumerable<TEntity> Query(string sql, dynamic param = null, TQuery query = default(TQuery), IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Query<TEntity>(sql, param, query, transaction, buffered, commandTimeout, commandType);
        }

        protected IEnumerable<T> Query<T>(string sql, dynamic param = null, TQuery query = default(TQuery), IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (IDbConnection connection = GetDbConnection())
            {
                var result = TrimStrings<T>(Dapper.SqlMapper.Query<T>(connection, sql, param, transaction, buffered, commandTimeout, commandType));

                if (query != null)
                    return Fill(result, query);
                else
                    return result;
            }
        }

        protected void Execute(string sql, dynamic param = null)
        {
            using (IDbConnection connection = GetDbConnection())
            {
                Dapper.SqlMapper.Execute(connection, sql, param);
            }
        }

        protected abstract IEnumerable<TEntity> Fill(IEnumerable<TEntity> entity, TQuery query);

        #region Private

        private IEnumerable<T> TrimStrings<T>(IEnumerable<T> objects)
        {
            var publicInstanceStringProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType == typeof(string) && x.CanRead && x.CanWrite);
            foreach (var prop in publicInstanceStringProperties)
            {
                foreach (var obj in objects)
                {
                    var value = (string)prop.GetValue(obj);
                    var trimmedValue = SafeTrim(value);
                    prop.SetValue(obj, trimmedValue);
                }
            }
            return objects;
        }

        private string SafeTrim(string source)
        {
            if (source == null)
            {
                return null;
            }
            return source.Trim();
        }

        #endregion
    }
}
