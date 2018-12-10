using Andromedarproject.MessageRouter.Services.AdressValidator;
using Andromedarproject.MessageRouter.Services.ContentMessageServices;
using Microsoft.Extensions.DependencyInjection;

namespace Andromedarproject.MessageRouter.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddServices<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddAdressValidation().TryAddContentRouter<TContent>();
            return serviceCollection;
        }
    }
}
