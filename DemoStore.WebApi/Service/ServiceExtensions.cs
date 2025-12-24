using DemoStore.WebApi;
using Microsoft.Extensions.DependencyInjection;

namespace DemoStore.WebApi
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(AutoMappingProfile));
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
