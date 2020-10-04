using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Infra;
using WebMotors.Domain.Handlers;

namespace WebMotors.API.Config
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependenciesConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //Infrastructure
            services.RegisterInfraServices();

            //Handlers
            services.AddTransient<AnuncioWebMotorsCommandHandler, AnuncioWebMotorsCommandHandler>();

            return services;
        }
    }
}
