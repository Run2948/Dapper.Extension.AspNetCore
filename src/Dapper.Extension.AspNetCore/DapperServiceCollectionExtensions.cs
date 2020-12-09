using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dapper.Extension.AspNetCore
{
    public static class DapperServiceCollectionExtensions
    {
        private static IServiceCollection AddDapper<TDbProvider>(this IServiceCollection services) where TDbProvider : IDapper
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.AddOptions();
            services.TryAddScoped(typeof(IDapper), typeof(TDbProvider));
            return services;
        }

        private static IServiceCollection AddDapper<TDbProvider>(this IServiceCollection services, IConfigurationSection section) where TDbProvider : IDapper
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (section == null)
                throw new ArgumentNullException(nameof(section));
            services.AddDapper<TDbProvider>();
            services.Configure<DapperOptions>(section);
            return services;
        }

        public static IServiceCollection AddDapper<TDbProvider>(this IServiceCollection services, Action<DapperOptions> setupAction) where TDbProvider : IDapper
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));
            services.AddDapper<TDbProvider>();
            services.Configure(setupAction);
            return services;
        }
    }
}
