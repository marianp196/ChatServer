using Andromedarproject.MessageDto.Adresses;
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
            sc.TryAddSingleton<IDictionary<Adress, StorageObject<string>>>( sp => new Dictionary<Adress, StorageObject<string>>());
            sc.TryAddTransient<IConnectionPoolReader<string>, ConnectionPool<string>>();
            sc.TryAddTransient<IConnectionPoolWriter<string>, ConnectionPool<string>>();
            return sc;
        }
    }
}
