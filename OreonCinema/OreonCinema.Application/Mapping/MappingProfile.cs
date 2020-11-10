namespace OreonCinema.Application.Mapping
{
    using AutoMapper;
    using System;
    using System.Linq;
    using System.Reflection;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsMapFrom(Assembly.GetExecutingAssembly());
            ApplyMappingsMapTo(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsMapFrom(Assembly assembly)
         => ApplyMappingsByMapperStrategyType(assembly, typeof(IMapFrom<>));

        private void ApplyMappingsMapTo(Assembly assembly)
        => ApplyMappingsByMapperStrategyType(assembly, typeof(IMapTo<>));

        private void ApplyMappingsByMapperStrategyType(Assembly assembly, Type mapperStrategyType)
        {
            var types = assembly
                .GetExportedTypes()
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperStrategyType))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                const string mappingMethodName = "Mapping";

                var methodInfo = type.GetMethod(mappingMethodName)
                                 ?? mapperStrategyType.GetMethod(mappingMethodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
