using Andromedarproject.MessageRouter.Output;
using AndromededarProject.Web.Output.Moq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AndromededarProject.Web.Output.ServerClients
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddClientOutputMoq<TContent>(this IServiceCollection sc)
        {

            sc.TryAddSingleton<IServerOutput<TContent>, ConsoleServerOutput<TContent>>();
            sc.TryAddSingleton<IClientOutput<TContent>, ClientOutput<TContent>>();
            return sc;
        }
    }
}
