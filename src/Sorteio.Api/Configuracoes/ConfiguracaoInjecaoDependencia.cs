

using Sorteio.Data.Context;

namespace Sorteio.Api.Configuracoes
{
    public static class ConfiguracaoInjecaoDependencia
    {
        
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            //Data
            services.AddScoped<SorteioDbContext>();

            return services;
        }
 
    }
}
