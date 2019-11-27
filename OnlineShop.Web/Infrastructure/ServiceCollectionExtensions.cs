using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Services.Common;
using System.Linq;

namespace OnlineShop.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var serviceInterfaceType = typeof(ITransientService);
            var scopedServiceInterfaceType = typeof(IScopedService);
            var singletonServiceInterfaceType = typeof(ISingletonService);

            var types = serviceInterfaceType
                            .Assembly
                            .GetExportedTypes()
                            .Where(t => t.IsClass && !t.IsAbstract)
                            .Select(t => new
                            {
                                Service = t.GetInterface($"I{t.Name}"),
                                Implementation = t
                            })
                            .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (serviceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (singletonServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else if (scopedServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }

            return services;
        }

        //old reflection
        //Assembly
        //    .GetAssembly(typeof(IService))
        //    .GetTypes()
        //    .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
        //    .Select(t => new
        //    {
        //        Interface = t.GetInterface($"I{t.Name}"),
        //        Service = t
        //    })
        //    .ToList()
        //    .ForEach(s => services.AddTransient(s.Interface, s.Service));

        //return services;
    }
}
