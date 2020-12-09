using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;

namespace Dapper.Extension.AspNetCore
{
    public abstract partial class BaseDapper<TDbConnection> : IDapper where TDbConnection : DbConnection, new()
    {
        public Lazy<IDbConnection> Conn { get; }

        protected IDbTransaction Transaction { get; set; }

        protected BaseDapper(IOptions<DapperOptions> optionsAccessor)
        {
            if (optionsAccessor == null)
                throw new ArgumentNullException(nameof(optionsAccessor));

            var options = optionsAccessor.Value;

            Conn = new Lazy<IDbConnection>(() => CreateConnection(options));
        }

        private IDbConnection CreateConnection(DapperOptions options)
        {
            var connString = options.ConnectionString;
            var conn = new TDbConnection();
            if (conn == null)
                throw new ArgumentNullException(nameof(IDbConnection), "Failed to create database connection.");
            conn.ConnectionString = connString;
            conn.Open();
            return conn;
        }


        public virtual List<TReturn> Query<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query<TReturn>(sql, param, Transaction, buffered, commandTimeout, commandType).ToList();
        }


        public virtual List<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query(sql, map, param, Transaction, buffered, splitOn, commandTimeout, commandType).ToList();
        }


        public virtual List<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query(sql, map, param, Transaction, buffered, splitOn, commandTimeout, commandType).ToList();
        }


        public virtual List<TResult> Query<TFirst, TSecond, TThird, TFourth, TResult>(string sql, Func<TFirst, TSecond, TThird, TFourth, TResult> map, object param = null, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query(sql, map, param, Transaction, buffered, splitOn, commandTimeout, commandType).ToList();
        }


        public virtual List<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query(sql, map, param, Transaction, buffered, splitOn, commandTimeout, commandType).ToList();
        }


        public virtual List<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query(sql, map, param, Transaction, buffered, splitOn, commandTimeout, commandType).ToList();
        }

        public virtual List<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
            object param = null, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query(sql, map, param, Transaction, buffered, splitOn, commandTimeout, commandType).ToList();
        }


        public virtual List<dynamic> Query(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null, bool buffered = true)
        {
            return Conn.Value.Query(sql, param, Transaction, buffered, commandTimeout, commandType).ToList();
        }


        public virtual TReturn QueryFirstOrDefault<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Conn.Value.QueryFirstOrDefault<TReturn>(sql, param, Transaction, commandTimeout, commandType);
        }


        public virtual dynamic QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Conn.Value.QueryFirstOrDefault(sql, param, Transaction, commandTimeout, commandType);
        }


        public virtual dynamic QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Conn.Value.QuerySingleOrDefault(sql, param, Transaction, commandTimeout, commandType);
        }


        public virtual TReturn QuerySingleOrDefault<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Conn.Value.QuerySingleOrDefault<TReturn>(sql, param, Transaction, commandTimeout, commandType);
        }


        public virtual void QueryMultiple(string sql, Action<SqlMapper.GridReader> reader, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using var multi = Conn.Value.QueryMultiple(sql, param, Transaction, commandTimeout, commandType);
            reader(multi);
        }


        public virtual IDataReader ExecuteReader(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Conn.Value.ExecuteReader(sql, param, Transaction, commandTimeout, commandType);
        }

        public virtual PageResult<TReturn> QueryPage<TReturn>(string countSql, string dataSql, int pageindex, int pageSize, object param = null, int? commandTimeout = null)
        {
            if (pageindex < 1)
                throw new ArgumentException("The pageindex cannot be less then 1.");
            if (pageSize < 1)
                throw new ArgumentException("The pageSize cannot be less then 1.");
            var pars = new DynamicParameters();
            if (param != null)
                pars.AddDynamicParams(param);

            pars.AddDynamicParams(new
            {
                TakeStart = (pageindex - 1) * pageSize + 1,
                TakeEnd = pageindex * pageSize,
                Skip = (pageindex - 1) * pageSize,
                Take = pageSize
            });
            var sql = $"{countSql}{(countSql.EndsWith(";") ? "" : ";")}{dataSql}";

            using var multi = Conn.Value.QueryMultiple(sql, pars, Transaction, commandTimeout);
            var count = multi.Read<long>().FirstOrDefault();
            var data = multi.Read<TReturn>().ToList();
            var result = new PageResult<TReturn>
            {
                TotalCount = count,
                Page = pageindex,
                PageSize = pageSize,
                Contents = data
            };
            result.TotalPage = result.TotalCount % pageSize == 0
                ? result.TotalCount / pageSize
                : result.TotalCount / pageSize + 1;
            if (result.Page > result.TotalPage)
                result.Page = result.TotalPage;
            return result;
        }

        public virtual List<TReturn> QueryPlainPage<TReturn>(string sql, int pageindex, int pageSize, object param = null, int? commandTimeout = null)
        {
            if (pageindex < 1)
                throw new ArgumentException("The pageindex cannot be less then 1.");
            if (pageSize < 1)
                throw new ArgumentException("The pageSize cannot be less then 1.");
            var pars = new DynamicParameters();
            if (param != null)
                pars.AddDynamicParams(param);

            pars.AddDynamicParams(new
            {
                TakeStart = (pageindex - 1) * pageSize + 1,
                TakeEnd = pageindex * pageSize,
                Skip = (pageindex - 1) * pageSize,
                Take = pageSize
            });

            return Conn.Value.Query<TReturn>(sql, pars, Transaction, true, commandTimeout).ToList();
        }

        public virtual PageResult<dynamic> QueryPage(string countSql, string dataSql, int pageindex, int pageSize, object param = null,
            int? commandTimeout = null)
        {
            if (pageindex < 1)
                throw new ArgumentException("The pageindex cannot be less then 1.");
            if (pageSize < 1)
                throw new ArgumentException("The pageSize cannot be less then 1.");
            var pars = new DynamicParameters();
            if (param != null)
                pars.AddDynamicParams(param);

            pars.AddDynamicParams(new
            {
                TakeStart = (pageindex - 1) * pageSize + 1,
                TakeEnd = pageindex * pageSize,
                Skip = (pageindex - 1) * pageSize,
                Take = pageSize
            });
            var sql = $"{countSql}{(countSql.EndsWith(";") ? "" : ";")}{dataSql}";

            using var multi = Conn.Value.QueryMultiple(sql, pars, Transaction, commandTimeout);
            var count = multi.Read<long>().FirstOrDefault();
            var data = multi.Read().ToList();
            var result = new PageResult<dynamic>
            {
                TotalCount = count,
                Page = pageindex,
                PageSize = pageSize,
                Contents = data
            };
            result.TotalPage = result.TotalCount % pageSize == 0
                ? result.TotalCount / pageSize
                : result.TotalCount / pageSize + 1;
            if (result.Page > result.TotalPage)
                result.Page = result.TotalPage;
            return result;
        }

        public virtual List<dynamic> QueryPlainPage(string sql, int pageindex, int pageSize, object param = null, int? commandTimeout = null)
        {
            if (pageindex < 1)
                throw new ArgumentException("The pageindex cannot be less then 1.");
            if (pageSize < 1)
                throw new ArgumentException("The pageSize cannot be less then 1.");
            var pars = new DynamicParameters();
            if (param != null)
                pars.AddDynamicParams(param);

            pars.AddDynamicParams(new
            {
                TakeStart = (pageindex - 1) * pageSize + 1,
                TakeEnd = pageindex * pageSize,
                Skip = (pageindex - 1) * pageSize,
                Take = pageSize
            });

            return Conn.Value.Query(sql, pars, Transaction, true, commandTimeout).ToList();
        }

        public virtual int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Conn.Value.Execute(sql, param, Transaction, commandTimeout, commandType);
        }


        public virtual TReturn ExecuteScalar<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Conn.Value.ExecuteScalar<TReturn>(sql, param, Transaction, commandTimeout, commandType);
        }


        #region Transaction

        public virtual IDbTransaction BeginTransaction()
        {
            return Transaction = Conn.Value.BeginTransaction();
        }

        public virtual IDbTransaction BeginTransaction(IsolationLevel level)
        {
            return Transaction = Conn.Value.BeginTransaction(level);
        }


        public virtual void CommitTransaction()
        {
            if (Transaction == null)
                throw new InvalidOperationException("Please call the BeginTransaction method first.");
            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }


        public virtual void RollbackTransaction()
        {
            if (Transaction == null)
                throw new InvalidOperationException("Please call the BeginTransaction method first.");
            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        public T Get<T>(object id, int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.Get<T>(id, Transaction, commandTimeout);
        }

        public IEnumerable<T> GetAll<T>(int? commandTimeout = null) where T : class, new()
        {
            return Conn.Value.GetAll<T>(Transaction, commandTimeout);
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

        #endregion

        public virtual void Dispose()
        {
            if (!Conn.IsValueCreated) return;
            Transaction?.Dispose();
            Conn.Value?.Close();
            Conn.Value?.Dispose();
        }
    }
}
