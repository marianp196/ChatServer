using Andromedarproject.MessageRouter.BasicMessagePipe;
using Andromedarproject.MessageRouter.Output.OutputCache;
using Andromedarproject.MessageRouter.Output.OutputServices;
using Microsoft.Extensions.DependencyInjection;

namespace Andromedarproject.MessageRouter.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddServices<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddOutputServcies<TContent>().
                TryAddOutputCache<TContent>().                            
                TryAddContentRouter<TContent>();
            return serviceCollection;
        }
    }
}
