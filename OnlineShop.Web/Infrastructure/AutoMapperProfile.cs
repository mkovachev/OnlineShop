using AutoMapper;
using OnlineShop.Common.Mapping;
using System;
using System.Linq;

namespace OnlineShop.Web.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        //    public AutoMapperProfile()
        //    {
        //        var mapFromType = typeof(IMapFrom<>);
        //        var mapToType = typeof(IMapTo<>);
        //        var explicitMapType = typeof(IMapExplicitly);

        //        // TODO not working
        //        var modelRegistrations =
        //            AppDomain
        //            .CurrentDomain
        //            .GetAssemblies()
        //            .Where(a => a.GetName().Name.StartsWith("OnlineShop."))
        //            .SelectMany(a => a.GetExportedTypes())
        //            .Where(t => t.IsClass && !t.IsAbstract)
        //            .Select(t => new
        //            {
        //                Type = t,
        //                MapFrom = this.GetMappingModel(t, mapFromType),
        //                MapTo = this.GetMappingModel(t, mapToType),
        //                ExplicitMap = t.GetInterfaces()
        //                               .Where(i => i == explicitMapType)
        //                               .Select(i => (IMapExplicitly)Activator.CreateInstance(t))
        //                               .FirstOrDefault()
        //            });

        //        foreach (var modelRegistration in modelRegistrations)
        //        {
        //            if (modelRegistration.MapFrom != null)
        //            {
        //                this.CreateMap(modelRegistration.MapFrom, modelRegistration.Type);
        //            }

        //            if (modelRegistration.MapTo != null)
        //            {
        //                this.CreateMap(modelRegistration.Type, modelRegistration.MapTo);
        //            }

        //            modelRegistration.ExplicitMap?.RegisterMappings(this);
        //        }
        //    }

        //    private Type GetMappingModel(Type type, Type mappingInterface)
        //        => type.GetInterfaces()
        //               .FirstOrDefault(i => i.IsGenericType
        //                             && i.GetGenericTypeDefinition() == mappingInterface
        //                                ?.GetGenericArguments()
        //               .First());
        //}

        // solution 2 working
        public AutoMapperProfile()
        {
            var allTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().Name.StartsWith("OnlineShop."))
                .SelectMany(a => a.GetTypes());

            allTypes
                .Where(t => t.IsClass && !t.IsAbstract && t
                    .GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Select(i => i.GetGenericTypeDefinition())
                    .Contains(typeof(IMapFrom<>)))
                .Select(t => new
                {
                    Destination = t,
                    Source = t
                        .GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Select(i => new
                        {
                            Definition = i.GetGenericTypeDefinition(),
                            Arguments = i.GetGenericArguments()
                        })
                        .Where(i => i.Definition == typeof(IMapFrom<>))
                        .SelectMany(i => i.Arguments)
                        .First(),
                })
                .ToList()
                .ForEach(mapping => this.CreateMap(mapping.Source, mapping.Destination));

            allTypes
                .Where(t => t.IsClass
                    && !t.IsAbstract
                    && typeof(IMapExplicitly).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IMapExplicitly>()
                .ToList()
                .ForEach(mapping => mapping.RegisterMappings(this));
        }
    }
}

