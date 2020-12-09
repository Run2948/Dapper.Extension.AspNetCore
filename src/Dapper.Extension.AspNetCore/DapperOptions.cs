using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace Dapper.Extension.AspNetCore
{
    public class DapperOptions : IOptions<DapperOptions>
    {
        public string ConnectionString { get; set; } 

        DapperOptions IOptions<DapperOptions>.Value => this;
    }
}
