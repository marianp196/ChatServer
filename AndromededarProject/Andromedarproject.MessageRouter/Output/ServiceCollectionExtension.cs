using Andromedarproject.MessageRouter.Output.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Output
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddRouterOutput<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddTransient<IOutput<TContent>, OutputSwitch<TContent>>();
            return serviceCollection;
        }
    }
}
