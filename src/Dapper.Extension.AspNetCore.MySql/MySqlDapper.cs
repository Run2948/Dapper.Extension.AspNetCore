using System;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace Dapper.Extension.AspNetCore.MySql
{
    public class MySqlDapper : BaseDapper<MySqlConnection>
    {
        public MySqlDapper(IOptions<DapperOptions> optionsAccessor)
            : base(optionsAccessor)
        {

        }
    }
}
