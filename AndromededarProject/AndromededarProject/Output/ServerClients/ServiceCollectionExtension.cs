using Andromedarproject.MessageRouter.Output.Abstractions;
using AndromededarProject.Web.Output.Moq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.Output.ServerClients
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddClientOutput<TContent>(this IServiceCollection sc)
        {

            sc.TryAddSingleton<IServerOutput<TContent>, ConsoleServerOutput<TContent>>();
            sc.TryAddSingleton<IClientOutput<TContent>, ClientOutput<TContent>>();
            return sc;
        }
    }
}
