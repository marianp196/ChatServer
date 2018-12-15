using Andromedarproject.MessageRouter.Services.ContentMessageServices;
using Microsoft.Extensions.DependencyInjection;

namespace Andromedarproject.MessageRouter.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddServices<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddContentRouter<TContent>();
            return serviceCollection;
        }
    }
}
