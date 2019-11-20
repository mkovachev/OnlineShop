using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace OnlineShop.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Service = t
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Service));

            return services;
        }
    }
}
