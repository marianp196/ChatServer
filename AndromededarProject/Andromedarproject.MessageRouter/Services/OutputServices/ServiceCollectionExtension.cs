using Andromedarproject.MessageRouter.Output;
using Andromedarproject.MessageRouter.Services.OutputCache;
using Andromedarproject.MessageRouter.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Andromedarproject.MessageRouter.Services.OutputServices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddOutputServcies<TContent>(this IServiceCollection sc)
        {
            sc.TryAddTransient<IOutputService<TContent>>( sp =>
            {
                return new CachedOutputService<TContent>(sp.GetService<IOutputCache<TContent>>(),
                        new OutputSwitchService<TContent>(sp.GetService<IServerOutput<TContent>>(),
                                                          sp.GetService<IClientOutput<TContent>>(),                                                             
                                                            sp.GetService<IInstanceInformation>()));
            });
            return sc;
        }
    }
}
