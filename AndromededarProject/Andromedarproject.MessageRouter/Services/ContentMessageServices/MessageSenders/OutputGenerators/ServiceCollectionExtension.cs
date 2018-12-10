using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.MessageInputOutputConverter;
using Andromedarproject.Users.Abstractions.Groups;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTargetTypeCases<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IOutputGenerator<TContent>, UserOutputGenerator<TContent>>();
            serviceCollection.AddTransient<IOutputGenerator<TContent>, GroupOutputGenerator<TContent>>();

            /*serviceCollection.TryAddTransient<IEnumerable<ITargetTypeCase<TContent>>>(sp =>
            {
                return new List<ITargetTypeCase<TContent>>()
                {
                    new UserTypeCase<TContent>(sp.GetService<IInputOutputConverter<TContent>>()),
                    new GroupTypeCase<TContent>(sp.GetService<IInputOutputConverter<TContent>>(), 
                    sp.GetService<IGroupReader>())
                };
            });*/
            return serviceCollection;
        }
    }
}

