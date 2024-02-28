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
    [Route("api/participante-sorteio")]
    public class ParticipanteSorteioController : MainController
    {
        private readonly IParticipanteSorteioService _participanteSorteioService;
        private readonly IMapper _mapper;
        public ParticipanteSorteioController(IParticipanteSorteioService participanteSorteioService,
                                      IMapper mapper,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _participanteSorteioService = participanteSorteioService;
        }

        [HttpGet]
        public async Task<IEnumerable<ParticipanteSorteioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ParticipanteSorteioViewModel>>(await _participanteSorteioService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ParticipanteSorteioViewModel>> ObterPorId(Guid id)
        {
            var participanteSorteioViewModel = _mapper.Map<ParticipanteSorteioViewModel>(await _participanteSorteioService.ObterPorId(id));

            if (participanteSorteioViewModel == null) return NotFound();

            return participanteSorteioViewModel;
        }

        [ClaimsAuthorize("ParticipanteSorteio", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ParticipanteSorteioViewModel>> Adicionar(ParticipanteSorteioViewModel participanteSorteioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _participanteSorteioService.Adicionar(_mapper.Map<ParticipanteSorteio>(participanteSorteioViewModel), new ParticipanteSorteioValidation());

            return CustomResponse(participanteSorteioViewModel);
        }

        [ClaimsAuthorize("ParticipanteSorteio", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ParticipanteSorteioViewModel participanteSorteioViewModel)
        {
            if (id != participanteSorteioViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);



            await _participanteSorteioService.Atualizar(_mapper.Map<ParticipanteSorteio>(participanteSorteioViewModel), new ParticipanteSorteioValidation());

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [ClaimsAuthorize("ParticipanteSorteio", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ParticipanteSorteioViewModel>> Excluir(Guid id)
        {

            await _participanteSorteioService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }



    }
}
