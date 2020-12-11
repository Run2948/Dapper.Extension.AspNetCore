using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Dapper.Extension.AspNetCore
{
    public abstract partial class BaseDapper<TDbConnection> where TDbConnection : DbConnection, new()
    {
        public T Get<T>(object id, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Get<T>(id, Transaction, commandTimeout);
        }

        public IEnumerable<T> GetAll<T>(int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.GetAll<T>(Transaction, commandTimeout);
        }

        public int Count<T>(int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Count<T>(Transaction, commandTimeout);
        }

        public dynamic Insert<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Insert(entities, Transaction, commandTimeout);
        }

        public dynamic Insert<T>(T entity, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Insert(entity, Transaction, commandTimeout);
        }

        public bool Update<T>(T entity, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Update(entity, Transaction, commandTimeout);
        }

        public bool Update<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Update(entities, Transaction, commandTimeout);
        }

        public bool Delete<T>(T entity, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Delete(entity, Transaction, commandTimeout);
        }

        public bool Delete<T>(object predicate, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Delete(predicate, Transaction, commandTimeout);
        }

        public bool DeleteAll<T>(int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.DeleteAll<T>(Transaction, commandTimeout);
        }
    }
}
