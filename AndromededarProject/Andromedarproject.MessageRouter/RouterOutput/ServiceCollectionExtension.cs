using Andromedarproject.MessageRouter.RouterOutput.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.RouterOutput
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddRouterOutput(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddTransient(typeof(IOutput<>), typeof(OutputSwitch<>));
            return serviceCollection;
        }
    }
}
