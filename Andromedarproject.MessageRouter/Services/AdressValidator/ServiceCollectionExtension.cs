using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.AdressValidator
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddAdressValidation(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAddressValidator, AdressValidator>();
            serviceCollection.AddTransient<ISenderAddressValidator, SenderAddressValidator>();
            serviceCollection.AddTransient<ITargetAddressValidator, TargetAddressValidator>();
            return serviceCollection;
        }
    }
}
