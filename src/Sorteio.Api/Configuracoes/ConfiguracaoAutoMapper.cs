using AutoMapper;
using Sorteio.Api.Models;
using Sorteio.Business.Models;

namespace Sorteio.Api.Configuracoes
{
    public class ConfiguracaoAutoMapper:Profile
    {

        public ConfiguracaoAutoMapper()
        {
            CreateMap<DadosSorteio, DadosSorteioViewModel>().ReverseMap();
            CreateMap<DadosSorteioViewModel, DadosSorteio>().ReverseMap();

            CreateMap<HistoricoSorteio, HistoricoSorteioViewModel>().ReverseMap();
            CreateMap<HistoricoSorteioViewModel, HistoricoSorteio>().ReverseMap();

            CreateMap<ParticipanteSorteio, ParticipanteSorteioViewModel>().ReverseMap();
            CreateMap<ParticipanteSorteioViewModel, ParticipanteSorteio>().ReverseMap();

            CreateMap<TicketSorteio, TicketSorteioViewModel>().ReverseMap();
            CreateMap<TicketSorteioViewModel, TicketSorteio>().ReverseMap();


        }


    }
}
