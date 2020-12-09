﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Extension.AspNetCore
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class PageResult<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public long Page { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public long PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalPage { get; set; }

        /// <summary>
        /// 内容数组
        /// </summary>

        public List<T> Contents { get; set; }
    }
}
