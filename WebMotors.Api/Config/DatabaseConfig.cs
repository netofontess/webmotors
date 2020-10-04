using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Infra.Database.Interceptors;
using WebMotors.Infra;

namespace WebMotors.API.Config
{
    /// <summary>
    /// 
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebMotorsContext>(options =>
            {
                options
                    .UseMySql(configuration.GetConnectionString("DefaultConnection"))
                    .AddInterceptors(new CommandInterceptor());
                //.UseLazyLoadingProxies();
            });

            return services;
        }
    }
}
