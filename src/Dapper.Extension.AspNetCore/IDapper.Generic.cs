using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Extension.AspNetCore
{
    public partial interface IDapper
    {
        /// <summary>
        /// Get entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        T Get<T>(object id, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="commandTimeout"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>(int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Count entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        int Count<T>(int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        dynamic Insert<T>(T entity, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        dynamic Insert<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Update entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Update<T>(T entity, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Update entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Update<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Delete<T>(T entity, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Delete by predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Delete<T>(object predicate, int? commandTimeout = null) where T : class, new();

        /// <summary>
        /// Delete all entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool DeleteAll<T>(int? commandTimeout = null) where T : class, new();
    }
}
