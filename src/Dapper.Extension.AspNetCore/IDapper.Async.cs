﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Extension.AspNetCore
{
    public partial interface IDapper
    {
        /// <summary>
        /// Return a sequence of dynamic objects with properties matching the columns.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<List<dynamic>> QueryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a query asynchronously, returning the data typed as T.
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<List<TReturn>> QueryAsync<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        
        /// <summary>
        /// Perform a multi-mapping query with 2 input types.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>am>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="sql"></param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param"></param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <returns></returns>
        Task<List<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true);

        
        /// <summary>
        /// Perform a multi-mapping query with 3 input types.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="sql"></param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param"></param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <returns></returns>
        Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true);

        
        /// <summary>
        /// Perform a multi-mapping query with 4 input types.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="sql"></param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param"></param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <returns></returns>
        Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true);

        
        /// <summary>
        /// Perform a multi-mapping query with 5 input types.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="sql"></param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param"></param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <returns></returns>
        Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true);


        /// <summary>
        /// Perform a multi-mapping query with 6 input types.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="sql"></param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param"></param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <returns></returns>
        Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true);

       
        /// <summary>
        /// Perform a multi-mapping query with 7 input types.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="sql"></param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param"></param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <returns></returns>
        Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, bool buffered = true);

        
        /// <summary>
        /// Execute a single-row query asynchronously,return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<dynamic> QueryFirstOrDefaultAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);


        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<TReturn> QueryFirstOrDefaultAsync<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a single-row query asynchronously.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<dynamic> QuerySingleOrDefaultAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        
        
        /// <summary>
        /// Executes a query, returning the data typed as T.
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<TReturn> QuerySingleOrDefaultAsync<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        
        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="reader"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task QueryMultipleAsync(string sql, Action<SqlMapper.GridReader> reader, object param = null, int? commandTimeout = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets.
        /// </summary>
        /// <typeparam name="TReturn1"></typeparam>
        /// <typeparam name="TReturn2"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<(List<TReturn1> Result1, List<TReturn2> Result2)> QueryMultipleAsync<TReturn1, TReturn2>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        
        /// <summary>
        /// Execute a command that returns multiple result sets.
        /// </summary>
        /// <typeparam name="TReturn1"></typeparam>
        /// <typeparam name="TReturn2"></typeparam>
        /// <typeparam name="TReturn3"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<(List<TReturn1> Result1, List<TReturn2> Result2, List<TReturn3> Result3)> QueryMultipleAsync<TReturn1, TReturn2, TReturn3>(string sql,
               object param = null, int? commandTimeout = null, CommandType? commandType = null);

        
        /// <summary>
        /// Execute a command that returns multiple result sets.
        /// </summary>
        /// <typeparam name="TReturn1"></typeparam>
        /// <typeparam name="TReturn2"></typeparam>
        /// <typeparam name="TReturn3"></typeparam>
        /// <typeparam name="TReturn4"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<(List<TReturn1> Result1, List<TReturn2> Result2, List<TReturn3> Result3, List<TReturn4> Result4)> QueryMultipleAsync
               <TReturn1, TReturn2, TReturn3, TReturn4>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        
        /// <summary>
        /// Execute a command that returns multiple result sets.
        /// </summary>
        /// <typeparam name="TReturn1"></typeparam>
        /// <typeparam name="TReturn2"></typeparam>
        /// <typeparam name="TReturn3"></typeparam>
        /// <typeparam name="TReturn4"></typeparam>
        /// <typeparam name="TReturn5"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<(List<TReturn1> Result1, List<TReturn2> Result2, List<TReturn3> Result3, List<TReturn4> Result4, List<TReturn5> Result5)> QueryMultipleAsync<TReturn1, TReturn2, TReturn3, TReturn4, TReturn5>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        
        
        /// <summary>
        /// Paging query.
        /// Paging index is required when paging data. The method has @Skip, @Take, @TakeStart, @TakeEnd 4 variables, MySql example: limit @Skip, @Take, MSSQL example: where row between @TakeStart and @TakeEnd
        /// </summary>
        /// <param name="countSql"></param>
        /// <param name="dataSql"></param>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<PageResult<dynamic>> QueryPageAsync(string countSql, string dataSql, int pageindex, int pageSize, object param = null, int? commandTimeout = null);


        /// <summary>
        /// Paging query.
        /// Paging index is required when paging data. The method has @Skip, @Take, @TakeStart, @TakeEnd 4 variables, MySql example: limit @Skip, @Take, MSSQL example: where row between @TakeStart and @TakeEnd
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="countSql"></param>
        /// <param name="dataSql"></param>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<PageResult<TReturn>> QueryPageAsync<TReturn>(string countSql, string dataSql, int pageindex, int pageSize, object param = null, int? commandTimeout = null);


        /// <summary>
        /// Paging query.
        /// Paging index is required when paging data. The method has @Skip, @Take, @TakeStart, @TakeEnd 4 variables, MySql example: limit @Skip, @Take, MSSQL example: where row between @TakeStart and @TakeEnd
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<List<dynamic>> QueryPlainPageAsync(string sql, int pageindex, int pageSize, object param = null, int? commandTimeout = null);
        
        
        /// <summary>
        /// Paging query.
        /// Paging index is required when paging data. The method has @Skip, @Take, @TakeStart, @TakeEnd 4 variables, MySql example: limit @Skip, @Take, MSSQL example: where row between @TakeStart and @TakeEnd
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<List<TReturn>> QueryPlainPageAsync<TReturn>(string sql, int pageindex, int pageSize, object param = null, int? commandTimeout = null);


        /// <summary>
        /// Execute a command asynchronously.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);


        /// <summary>
        ///  Execute parameterized SQL and return an System.Data.IDataReader.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);


        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        Task<TReturn> ExecuteScalarAsync<TReturn>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

    }
}
