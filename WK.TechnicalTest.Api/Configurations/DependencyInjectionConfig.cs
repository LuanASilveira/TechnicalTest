using WK.TechnicalTest.BLL.Interfaces.Repository;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.BLL.Services;
using WK.TechnicalTest.DAO;
using WK.TechnicalTest.DAO.Repository;

namespace WK.TechnicalTest.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Repositories.
            services.AddScoped<DataDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Services.
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

    }
}
