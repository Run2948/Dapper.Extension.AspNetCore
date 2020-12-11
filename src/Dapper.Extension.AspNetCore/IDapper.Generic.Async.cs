using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Extension.AspNetCore
{
    public partial interface IDapper
    {
        /// <summary>
        /// Get entity async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(object id, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="commandTimeout"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync<T>(int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Count entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<int> CountAsync<T>(int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Insert entity async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<dynamic> InsertAsync<T>(T entity, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Insert entities async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<dynamic> InsertAsync<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Update entity async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync<T>(T entity, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Update entities async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Delete entity async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Delete by predicate async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync<T>(object predicate, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Delete all entities async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> DeleteAllAsync<T>(int? commandTimeout = null) where T : class, new();
    }
}
