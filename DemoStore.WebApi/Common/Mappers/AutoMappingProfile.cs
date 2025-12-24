using AutoMapper;
using System.Reflection;
namespace DemoStore.WebApi
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        public AutoMappingProfile(params Assembly[] assemblies)
        {
            ApplyMappingFromAllAssembly(assemblies);
        }

        private void ApplyMappingFromAllAssembly(Assembly[] assemblies)
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
            foreach (Assembly assembly in assemblies)
            {
                ApplyMappingFromAssembly(assembly);
            }
        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes();

            var maps = types.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))).ToList();

            foreach (var map in maps)
            {
                var instance = Activator.CreateInstance(map);

                var methodInfo = map.GetMethod("Mapping") ?? map.GetInterface(typeof(IMapFrom<>).Name)?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }        
    }
}
