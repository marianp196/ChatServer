using Andromedarproject.MessageRouter.Services.ContentMessageServices;
using Andromedarproject.MessageRouter.Services.OutputServices;
using Microsoft.Extensions.DependencyInjection;

namespace Andromedarproject.MessageRouter.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddServices<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddOutputServcies<TContent>().TryAddContentRouter<TContent>();
            return serviceCollection;
        }
    }
}
