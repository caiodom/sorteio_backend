using Sorteio.Business.Interfaces.Repository;
using Sorteio.Business.Interfaces.Services;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Models.Validations;
using Sorteio.Business.Models;
using Sorteio.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Services
{
    public class HistoricoSorteioService : BaseService<HistoricoSorteio>, IHistoricoSorteioService
    {
        private readonly IHistoricoSorteioRepository _historicoSorteioRepository;

        public HistoricoSorteioService(IHistoricoSorteioRepository historicoSorteioRepository, INotificador notificador) : base(historicoSorteioRepository, notificador)
        {
            _historicoSorteioRepository = historicoSorteioRepository;
        }


        public async Task Adicionar(HistoricoSorteio historicoSorteio)
        {
            if (!ExecutarValidacao(new HistoricoSorteioValidation(), historicoSorteio))
                return;

            var dadoExistente = _historicoSorteioRepository.ObterPorId(historicoSorteio.Id);

            if (dadoExistente != null)
            {
                Notificar("Já existe um historico com o ID informado!");
                return;
            }

            await _historicoSorteioRepository.Adicionar(historicoSorteio);
        }


        public async Task Atualizar(HistoricoSorteio historicoSorteio)
        {
            if (!ExecutarValidacao(new HistoricoSorteioValidation(), historicoSorteio))
                return;

            await _historicoSorteioRepository.Atualizar(historicoSorteio);

        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _historicoSorteioRepository.ObterPorId(id);

            if (fornecedor == null)
            {
                Notificar("Sorteio não existe!");
                return;
            }
            await _historicoSorteioRepository.Remover(id);
        }
    }
}

