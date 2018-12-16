using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.OutputServices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddOutputServcies<TContent>(this IServiceCollection sc)
        {
            sc.TryAddTransient<IOutputService<TContent>, OutputSwitchService<TContent>>();
            return sc;
        }
    }
}
