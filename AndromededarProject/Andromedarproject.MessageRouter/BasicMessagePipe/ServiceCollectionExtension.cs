using Andromedarproject.MessageRouter.BasicMessagePipe.SenderAuthorizationMiddleware;
using Andromedarproject.MessageRouter.BasicMessagePipe.TextContentMessage.OutputGenerators;
using Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware;
using Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.Validators;
using Andromedarproject.MessageRouter.BasicMessagePipe.ValidationMiddleware.ValidatorServices;
using Andromedarproject.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Andromedarproject.MessageRouter.BasicMessagePipe
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddBasicMessagePipe<TContent>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddOutputGenerators<TContent>();
            serviceCollection.TryAddValidatorService<Message<TContent>>()
                .AddValidator<Message<TContent>, MetaDataValidator<TContent>>()
                .AddValidator<Message<TContent>, TargetAdressValidator<TContent>>();

            serviceCollection.TryAddTransient<IContentRouter<TContent>>( sp =>
            {
                return new SenderAuthorization<TContent>(sp.GetService<IUserReader>(),  
                       new ValidationService<TContent>(sp.GetService<IValidatorService<Message<TContent>>>(),
                      sp.GetService<IBasicMessagePipeOutput<TContent>>()));
            }
            );

            return serviceCollection;
        }
    }
}
