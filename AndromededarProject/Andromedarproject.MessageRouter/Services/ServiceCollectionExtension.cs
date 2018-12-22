using Andromedarproject.MessageRouter.BasicMessagePipe;
using Andromedarproject.MessageRouter.Output.OutputCache;
using Andromedarproject.MessageRouter.Output.OutputServices;
using Andromedarproject.MessageRouter.Services.TextContentMessage;
using Microsoft.Extensions.DependencyInjection;

namespace Andromedarproject.MessageRouter.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddTextContentService();
            return serviceCollection;
        }
    }
}
