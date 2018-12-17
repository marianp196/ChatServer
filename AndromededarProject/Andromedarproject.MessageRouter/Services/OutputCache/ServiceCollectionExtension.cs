using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;

namespace Andromedarproject.MessageRouter.Services.OutputCache
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddOutputCache<TContent>(this IServiceCollection sc)
        {
            sc.TryAddSingleton<IOutputCache<TContent>, InMemoryCache<TContent>>();
            return sc;
        }
    }
}
