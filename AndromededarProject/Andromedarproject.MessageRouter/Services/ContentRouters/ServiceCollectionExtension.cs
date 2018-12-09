using Andromedarproject.MessageRouter.RouterOutput.Abstractions;
using Andromedarproject.MessageRouter.Services.AdressValidator;
using Andromedarproject.MessageRouter.Services.ContentRouters.TargetTypeCaseSwitches;
using Andromedarproject.MessageRouter.Services.ContentRouters.TargetTypeCaseSwitches.MessageInputOutputConverter;
using Andromedarproject.MessageRouter.Services.ContentRouters.TargetTypeCaseSwitches.TargetTypeCases;
using Andromedarproject.MessageRouter.Services.ContentRouters.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentRouters
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddContentRouter<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddMessageInputOutputConverter<TContent>().AddTargetTypeCases<TContent>();

            serviceCollection.TryAddTransient<IContentRouter<TContent>>( sp =>
            {
                return new ContentRouterInputValidator<TContent>(
                       new ContentRouterInputSenderValidator<TContent>(sp.GetService<ISenderAddressValidator>(),
                       new ContentRouterInputTargetValidator<TContent>(sp.GetService<ITargetAddressValidator>(),
                       new ContentRouterTargetTypeCaseSwitch<TContent>(sp.GetService<IEnumerable<ITargetTypeCase<TContent>>>(),
                                                                       sp.GetService<IOutput<TContent>>(), null))));
            }
            );

            return serviceCollection;
        }
    }
}
