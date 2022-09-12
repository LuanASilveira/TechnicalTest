using WK.TechnicalTest.BLL.Extensions;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.BLL.Services;

namespace WK.TechnicalTest.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var apiSettings = configuration.GetSection("ApiSettings");
            services.Configure<ApiSettings>(apiSettings);

            //Services
            services.AddScoped<IApiService, ApiService>();

            return services;
        }
    }
}
