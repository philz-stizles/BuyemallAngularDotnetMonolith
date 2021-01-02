using BuyEmAll.Core.Configs;
using BuyEmAll.Core.Interfaces;
using BuyEmAll.Core.Interfaces.Services;
using BuyEmAll.Infrastructure.Data;
using BuyEmAll.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuyEmAll.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration Configuration)
        {
            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // This is specified with typeof because 
            // its generic value could be anything
            services.AddScoped<IProductRepository, ProductRepository>();


            // Services
            services.AddScoped<ITokenService, TokenService>();


            // Configurations
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            return services;
        }
    }
}