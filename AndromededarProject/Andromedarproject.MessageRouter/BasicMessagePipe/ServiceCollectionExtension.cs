using Andromedarproject.MessageRouter.Output;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.MessageSenders.OutputGenerators;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.SenderAuthorizationMiddleware;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.Validators;
using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.ValidatorServices;
using Andromedarproject.MessageRouter.Services.OutputServices;
using Andromedarproject.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddContentRouter<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddOutputGenerators<TContent>();
            serviceCollection.TryAddValidatorService<Message<TContent>>()
                .AddValidator<Message<TContent>, MetaDataValidator<TContent>>()
                .AddValidator<Message<TContent>, TargetAdressValidator<TContent>>();

            serviceCollection.TryAddTransient<IContentRouter<TContent>>( sp =>
            {
                return new SenderAuthorization<TContent>(sp.GetService<IUserReader>(),  
                       new ValidationService<TContent>(sp.GetService<IValidatorService<Message<TContent>>>(),
                       new ContentMessageSender<TContent>(sp.GetService<IEnumerable<IOutputGenerator<TContent>>>(),
                                                                       sp.GetService<IOutputService<TContent>>(), null)));
            }
            );

            return serviceCollection;
        }
    }
}
