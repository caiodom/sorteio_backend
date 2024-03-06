using AutoMapper;
using Microsoft.AspNetCore.Components;
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

            return CustomResponse(_mapper.Map<TicketSorteioViewModel>(_ticketSorteioService.Sortear(idDadosSorteio)));
        }
    }
}
