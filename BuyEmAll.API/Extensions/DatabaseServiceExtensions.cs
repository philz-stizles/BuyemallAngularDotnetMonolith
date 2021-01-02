using BuyEmAll.Infrastructure.Data;
using BuyEmAll.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuyEmAll.API.Extensions
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddDbContext<StoreContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}