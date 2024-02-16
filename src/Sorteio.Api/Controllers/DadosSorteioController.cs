using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sorteio.Api.Controllers.Base;
using Sorteio.Api.Models;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Interfaces.Services;
using Sorteio.Business.Models;
using Sorteio.Business.Models.Validations;
using System.Net;

namespace Sorteio.Api.Controllers
{
    [Route("api/sorteio")]
    public class DadosSorteioController : MainController
    {
        private readonly IDadosSorteioService _dadosSorteioService;
        private readonly IMapper _mapper;
        public DadosSorteioController(IDadosSorteioService dadosSorteioService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _dadosSorteioService=dadosSorteioService;
        }

        [HttpGet]
        public async Task<IEnumerable<DadosSorteioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<DadosSorteioViewModel>>(await _dadosSorteioService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DadosSorteioViewModel>> ObterPorId(Guid id)
        {
            var dadoSorteioViewModel = _mapper.Map<DadosSorteioViewModel>(await _dadosSorteioService.ObterPorId(id));

            if (dadoSorteioViewModel == null) return NotFound();

            return dadoSorteioViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<DadosSorteioViewModel>> Adicionar(DadosSorteioViewModel dadoSorteioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dadosSorteioService.Adicionar(_mapper.Map<DadosSorteio>(dadoSorteioViewModel),new DadosSorteioValidation());

            return CustomResponse(HttpStatusCode.Created, dadoSorteioViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, DadosSorteioViewModel dadoSorteioViewModel)
        {
            if (id != dadoSorteioViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

          

            await _dadosSorteioService.Atualizar(_mapper.Map<DadosSorteio>(dadoSorteioViewModel), new DadosSorteioValidation());

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DadosSorteioViewModel>> Excluir(Guid id)
        {

            await _dadosSorteioService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }



    }
}
