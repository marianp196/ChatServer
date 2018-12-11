using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ConnectionPool
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddConnectionPool(this IServiceCollection sc)
        {
            sc.TryAddSingleton<IConnectionPool, ConnectionPool>();
            return sc;
        }
    }
}
