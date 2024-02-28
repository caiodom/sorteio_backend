using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sorteio.Api.Controllers.Base;
using Sorteio.Api.Models;
using Sorteio.Business.Interfaces.Services;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Models.Validations;
using Sorteio.Business.Models;
using System.Net;
using Sorteio.Api.Extensoes;

namespace Sorteio.Api.Controllers
{
    [Route("api/ticket")]
    public class TicketSorteioController : MainController
    {
        private readonly ITicketSorteioService _ticketSorteioService;
        private readonly IMapper _mapper;
        public TicketSorteioController(ITicketSorteioService ticketSorteioService,
                                      IMapper mapper,
                                      INotificador notificador,
                                      IUser user) : base(notificador,user)
        {
            _mapper = mapper;
            _ticketSorteioService = ticketSorteioService;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketSorteioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TicketSorteioViewModel>>(await _ticketSorteioService.ObterTodos());
        }

        [HttpPost("sortear")]
        public  ActionResult<TicketSorteioViewModel> Sortear(Guid idDadosSorteio)
        {
            if (!ModelState.IsValid) 
                    return CustomResponse(ModelState);

            return CustomResponse(_mapper.Map<TicketSorteioViewModel>(_ticketSorteioService.Sortear(idDadosSorteio)));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TicketSorteioViewModel>> ObterPorId(Guid id)
        {
            var ticketSorteioViewModel = _mapper.Map<TicketSorteioViewModel>(await _ticketSorteioService.ObterPorId(id));

            if (ticketSorteioViewModel == null) return NotFound();

            return ticketSorteioViewModel;
        }

        [ClaimsAuthorize("TicketSorteio", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<TicketSorteioViewModel>> Adicionar(TicketSorteioViewModel ticketSorteioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _ticketSorteioService.Adicionar(_mapper.Map<TicketSorteio>(ticketSorteioViewModel), new TicketSorteioValidation());

            return CustomResponse(ticketSorteioViewModel);
        }

        [ClaimsAuthorize("TicketSorteio", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, TicketSorteioViewModel ticketSorteioViewModel)
        {
            if (id != ticketSorteioViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);



            await _ticketSorteioService.Atualizar(_mapper.Map<TicketSorteio>(ticketSorteioViewModel), new TicketSorteioValidation());

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [ClaimsAuthorize("TicketSorteio", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TicketSorteioViewModel>> Excluir(Guid id)
        {

            await _ticketSorteioService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }



    }
}
