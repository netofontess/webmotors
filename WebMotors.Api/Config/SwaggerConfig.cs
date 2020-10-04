using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebMotors.API.Config
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments("WebMotors.Api.xml");
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo()
                    {
                        Title = "WebMotors",
                        Version = "v1"
                    }
                );
            });

            return services;
        }
    }
}
