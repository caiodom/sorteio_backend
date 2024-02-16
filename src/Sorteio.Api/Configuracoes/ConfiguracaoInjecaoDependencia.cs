

using Sorteio.Business.Interfaces;
using Sorteio.Business.Interfaces.Repository;
using Sorteio.Business.Interfaces.Services;
using Sorteio.Business.Notificacoes;
using Sorteio.Business.Services;
using Sorteio.Data.Context;
using Sorteio.Data.Repository;

namespace Sorteio.Api.Configuracoes
{
    public static class ConfiguracaoInjecaoDependencia
    {
        
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            //Data
            services.AddScoped<SorteioDbContext>();
            services.AddScoped<IDadosSorteioRepository, DadosSorteioRepository>();
            services.AddScoped<IHistoricoSorteioRepository, HistoricoSorteioRepository>();
            services.AddScoped<IParticipanteSorteioRepository, ParticipanteSorteioRepository>();
            services.AddScoped<ITicketSorteioRepository, TicketSorteioRepository>();


            //Services
            services.AddScoped<IDadosSorteioService, DadosSorteioService>();
            services.AddScoped<IHistoricoSorteioService, HistoricoSorteioService>();
            services.AddScoped<IParticipanteSorteioService, ParticipanteSorteioService>();
            services.AddScoped<ITicketSorteioService, TicketSorteioService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
 
    }
}
