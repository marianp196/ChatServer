using Andromedarproject.MessageRouter.BasicMessagePipe;
using Andromedarproject.MessageRouter.ContentMessageServices;
using Andromedarproject.MessageRouter.ContentMessageServices.OutputGenerators;
using Andromedarproject.MessageRouter.Output.OutputCache;
using Andromedarproject.MessageRouter.Output.OutputServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddContentService<TContent>(this IServiceCollection sc)
        {
            sc.TryAddBasicMessagePipe<TContent>()
                .AddOutputGenerators<TContent>()
                .TryAddOutputServcies<TContent>()
                .TryAddOutputCache<TContent>()
                .TryAddTransient<IBasicMessagePipeOutput<TContent>, ContentMessageSender<TContent>>();
            return sc;
        }
    }
}
