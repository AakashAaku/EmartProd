using Microsoft.Extensions.DependencyInjection;

namespace EmartProd.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection RegisterApplicationConfig(this IServiceCollection services)
        {
          services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
          return services;
        }
    }
}