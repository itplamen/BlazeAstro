namespace BlazeAstro.Infrastructure.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    public class MappingProfile : Profile
    {
        private const string MappingMethodName = "Mapping";

        public MappingProfile(Assembly assembly) 
        {
            ApplyMappingsAssembly(assembly, typeof(IMapFrom<>));
            ApplyMappingsAssembly(assembly, typeof(IMapTo<>));
            LoadCustomMappings(assembly.GetExportedTypes());
        }

        private void ApplyMappingsAssembly(Assembly assembly, Type typeDefinition)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeDefinition))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(MappingMethodName) ?? type.GetInterface(typeDefinition.Name)?.GetMethod(MappingMethodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

        private void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps =
                types.SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                    .Where(
                        type =>
                            typeof(ICustomMapping).IsAssignableFrom(type.t) && 
                            !type.t.IsAbstract && 
                            !type.t.IsInterface)
                    .Select(type => (ICustomMapping)Activator.CreateInstance(type.t));

            foreach (var map in maps)
            {
                map.CreateMappings(this);
            }
        }
    }
}