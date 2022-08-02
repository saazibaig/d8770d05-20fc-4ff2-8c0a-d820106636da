using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeekAd.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekAd.Api.IoC
{
    public static class Bindings
    {
        public static IServiceCollection RegisterEngine(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IAdService, AdService>();

            return services;
        }

    }
}
