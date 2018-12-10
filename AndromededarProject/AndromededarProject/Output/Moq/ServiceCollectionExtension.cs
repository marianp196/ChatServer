using Andromedarproject.MessageRouter.Output.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
