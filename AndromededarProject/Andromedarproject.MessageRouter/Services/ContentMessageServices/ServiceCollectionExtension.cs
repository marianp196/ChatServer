﻿using Andromedarproject.MessageRouter.Output.Abstractions;
using Andromedarproject.MessageRouter.Services.AdressValidator;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.MessageInputOutputConverter;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddContentRouter<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddMessageInputOutputConverter<TContent>().AddOutputGenerators<TContent>();

            serviceCollection.TryAddTransient<IContentRouter<TContent>>( sp =>
            {
                return new ContentMessageInputValidator<TContent>(
                       new ContentMessageSenderValidator<TContent>(sp.GetService<ISenderAddressValidator>(),
                       new ContentRouterInputTargetValidator<TContent>(sp.GetService<ITargetAddressValidator>(),
                       new ContentMessageSender<TContent>(sp.GetService<IEnumerable<IOutputGenerator<TContent>>>(),
                                                                       sp.GetService<IOutput<TContent>>(), null))));
            }
            );

            return serviceCollection;
        }
    }
}