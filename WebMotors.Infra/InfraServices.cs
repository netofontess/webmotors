using Microsoft.Extensions.DependencyInjection;
using WebMotors.Infra.Database.Repository;
using WebMotors.Infra.Transactions;
using WebMotors.Shared.Transactions;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Infra;

namespace WebMotors.Infra
{
    public static class InfraServices
    {
        public static IServiceCollection RegisterInfraServices(this IServiceCollection services)
        {
            //Infra
            services.AddScoped<IUow, Uow>();
            services.AddScoped<WebMotorsContext, WebMotorsContext>();

            //Repositories
            services.AddTransient<IAnuncioWebMotorsRepository, AnuncioWebMotorsRepository>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<IModeloRepository, ModeloRepository>();
            services.AddTransient<IVersaoRepository, VersaoRepository>();

            return services;
        }
    }
}
