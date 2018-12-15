using Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.ValidatorServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.ContentMessageServices.ValidationMiddleware.ValidatorServices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddValidatorService<TObj>(this IServiceCollection sc)
        {
            sc.TryAddTransient<IValidatorService<TObj>, ValidatorService<TObj>>();
            return sc;
        }

        public static IServiceCollection AddValidator<TObj,TValidator>(this IServiceCollection sc)
            where TValidator : class, IValidator<TObj>
        {
            sc.AddTransient<IValidator<TObj>, TValidator>();
            return sc;
        }
    }
}
