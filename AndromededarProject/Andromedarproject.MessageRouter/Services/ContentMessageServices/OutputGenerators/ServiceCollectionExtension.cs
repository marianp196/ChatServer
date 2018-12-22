using Microsoft.Extensions.DependencyInjection;

namespace Andromedarproject.MessageRouter.ContentMessageServices.OutputGenerators
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOutputGenerators<TContent>(this IServiceCollection serviceCollection)
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

