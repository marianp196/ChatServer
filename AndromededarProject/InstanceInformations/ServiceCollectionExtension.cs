using Andromedarproject.MessageRouter.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.InstanceInformations
{
    public static  class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddInstanceInformation(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IInstanceInformation, InstanceInformationMoq>();
            return serviceCollection;
        }
    }
}
