using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Sorteio.Api.Controllers.Base;
using Sorteio.Api.Models;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Interfaces.Services;

namespace Sorteio.Api.Controllers
{
    [Route("api/sorteio")]
    public class SorteioController : MainController
    {

        private readonly ITicketSorteioService _ticketSorteioService;
        private readonly IMapper _mapper;
        public SorteioController(ITicketSorteioService ticketSorteioService,
                                 INotificador notificador,
                                 IMapper mapper,
                                 IUser appUser) : base(notificador, appUser)
        {
            _ticketSorteioService = ticketSorteioService;
            _mapper = mapper;
        }

        [HttpPost("sortear")]
        public ActionResult<TicketSorteioViewModel> Sortear(Guid idDadosSorteio)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);


            var x = _ticketSorteioService.Sortear(idDadosSorteio);

            if (x == null)
                return BadRequest();

            var dto = new TicketSorteioViewModel
            {
                Id = x.Id,
                IdDadosSorteio = x.IdDadosSorteio,
                IdParticipanteSorteio = x.IdParticipanteSorteio,
                DescricaoSorteio = x.DadosSorteio.Descricao,
                NomeParticipanteSorteio = x.ParticipanteSorteio.Nome,
                Numero = x.Numero

            };


            return CustomResponse(dto);
        }
    }
}
