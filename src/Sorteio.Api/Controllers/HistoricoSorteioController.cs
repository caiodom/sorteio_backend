﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sorteio.Api.Controllers.Base;
using Sorteio.Api.Models;
using Sorteio.Business.Interfaces.Services;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Models.Validations;
using Sorteio.Business.Models;
using System.Net;

namespace Sorteio.Api.Controllers
{
    [Route("api/historico")]
    public class HistoricoSorteioController : MainController
    {
        private readonly IHistoricoSorteioService _historicoSorteioService;
        private readonly IMapper _mapper;
        public HistoricoSorteioController(IHistoricoSorteioService historicoSorteioService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _historicoSorteioService = historicoSorteioService;
        }

        [HttpGet]
        public async Task<IEnumerable<HistoricoSorteioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<HistoricoSorteioViewModel>>(await _historicoSorteioService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HistoricoSorteioViewModel>> ObterPorId(Guid id)
        {
            var historicoSorteioViewModel = _mapper.Map<HistoricoSorteioViewModel>(await _historicoSorteioService.ObterPorId(id));

            if (historicoSorteioViewModel == null) return NotFound();

            return historicoSorteioViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<HistoricoSorteioViewModel>> Adicionar(HistoricoSorteioViewModel historicoSorteioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _historicoSorteioService.Adicionar(_mapper.Map<HistoricoSorteio>(historicoSorteioViewModel), new HistoricoSorteioValidation());

            return CustomResponse(HttpStatusCode.Created, historicoSorteioViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, HistoricoSorteioViewModel historicoSorteioViewModel)
        {
            if (id != historicoSorteioViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);



            await _historicoSorteioService.Atualizar(_mapper.Map<HistoricoSorteio>(historicoSorteioViewModel), new HistoricoSorteioValidation());

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<HistoricoSorteioViewModel>> Excluir(Guid id)
        {

            await _historicoSorteioService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }



    }
}