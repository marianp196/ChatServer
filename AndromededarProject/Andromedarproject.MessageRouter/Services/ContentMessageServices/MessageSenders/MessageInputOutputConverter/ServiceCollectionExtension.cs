using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.MessageInputOutputConverter
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddMessageInputOutputConverter<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddTransient<IInputOutputConverter<TContent>, InputOutputConverter<TContent>>();
            return serviceCollection;
        }
    }
    
}
