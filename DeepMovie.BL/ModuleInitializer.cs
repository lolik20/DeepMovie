using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DeepMovie.BL
{
    public static class ModuleInitializer
    {
        public static IServiceCollection ConfigureBL(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            var memoryCache = new MemoryCache(
                Options.Create(new MemoryCacheOptions())//в дальнейшем подключить Redis
            );
            services.AddSingleton<IMemoryCache>(memoryCache);
            return services;
        }

    }
}
