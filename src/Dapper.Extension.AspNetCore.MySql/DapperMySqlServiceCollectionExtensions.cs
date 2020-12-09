using System;
using Dapper.Extension.AspNetCore;
using Dapper.Extension.AspNetCore.MySql;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DapperMySqlServiceCollectionExtensions
    {
        // public static IServiceCollection AddDapperForMySql(this IServiceCollection services)
        // {
        //     return services.AddDapper<MySqlDapper>();
        // }
        //
        // public static IServiceCollection AddDapperForMySql(this IServiceCollection services, IConfigurationSection section)
        // {
        //     return services.AddDapper<MySqlDapper>(section);
        // }

        public static IServiceCollection AddDapperForMySql(this IServiceCollection services, string connectionString)
        {
            return services.AddDapper<MySqlDapper>(options => { options.ConnectionString = connectionString; });
        }

        public static IServiceCollection AddDapperForMySql(this IServiceCollection services, Action<DapperOptions> setupAction)
        {
            return services.AddDapper<MySqlDapper>(setupAction);
        }
    }
}