using Andromedarproject.MessageRouter.Output;
using Andromedarproject.Output.NetworkAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AndromededarProject.Web.Output.Moq
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddOutputMoq<TContent>(this IServiceCollection sc)
        {

            sc.TryAddSingleton<IServerOutput<TContent>, ConsoleServerOutput<TContent>>();
            sc.TryAddSingleton<IClientOutput<TContent>, ConsoleClientOutput<TContent>>();
            return sc;
        }
    }
}
