using Mapster;
using MapsterMapper;
//using MapsterMapper;
using System.Reflection;

namespace BookStoreApi.Mapping
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
