using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Extension.AspNetCore
{
    public abstract partial class BaseDapper<TDbConnection> where TDbConnection : DbConnection, new()
    {
        public async Task<T> GetAsync<T>(object id, int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.GetAsync<T>(id, Transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.GetAllAsync<T>(Transaction, commandTimeout);
        }

        public async Task<int> CountAsync<T>(int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.CountAsync<T>(Transaction, commandTimeout);
        }

        public async Task<dynamic> InsertAsync<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.InsertAsync(entities, Transaction, commandTimeout);
        }

        public async Task<dynamic> InsertAsync<T>(T entity, int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.InsertAsync(entity, Transaction, commandTimeout);
        }

        public async Task<bool> UpdateAsync<T>(T entity, int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.UpdateAsync(entity, Transaction, commandTimeout);
        }

        public async Task<bool> UpdateAsync<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.UpdateAsync(entities, Transaction, commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.DeleteAsync(entity, Transaction, commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(object predicate, int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.DeleteAsync(predicate, Transaction, commandTimeout);
        }

        public async Task<bool> DeleteAllAsync<T>(int? commandTimeout = null) where T : class, new()
        {
            return await Conn.Value.DeleteAllAsync<T>(Transaction, commandTimeout);
        }
    }
}
