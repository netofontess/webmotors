using Microsoft.Extensions.DependencyInjection;

namespace WebMotors.API.Config
{
    /// <summary>
    /// 
    /// </summary>
    public static class CorsConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy",
                    policy =>
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                );
            });

            return services;
        }
    }
}
