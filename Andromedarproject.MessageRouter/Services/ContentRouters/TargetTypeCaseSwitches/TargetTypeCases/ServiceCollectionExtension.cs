using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentRouters.TargetTypeCaseSwitches.TargetTypeCases
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTargetTypeCases(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(ITargetTypeCase<>), typeof(UserTypeCase<>));
            serviceCollection.AddTransient(typeof(ITargetTypeCase<>), typeof(GroupTypeCase<>));
            return serviceCollection;
        }
    }
}
}
