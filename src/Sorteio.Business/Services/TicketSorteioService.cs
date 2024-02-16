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
    public class TicketSorteioService : BaseService<TicketSorteio>, ITicketSorteioService
    {
        private readonly ITicketSorteioRepository _ticketSorteioRepository;

        public TicketSorteioService(ITicketSorteioRepository ticketSorteioRepository, INotificador notificador) : base(ticketSorteioRepository, notificador)
        {
            _ticketSorteioRepository = ticketSorteioRepository;
        }


        public async Task Adicionar(TicketSorteio ticketSorteio)
        {
            if (!ExecutarValidacao(new TicketSorteioValidation(), ticketSorteio))
                return;

            var dadoExistente = _ticketSorteioRepository.ObterPorId(ticketSorteio.Id);

            if (dadoExistente != null)
            {
                Notificar("Já existe um sorteio com o ID informado!");
                return;
            }

            await _ticketSorteioRepository.Adicionar(ticketSorteio);
        }


        public async Task Atualizar(TicketSorteio ticketSorteio)
        {
            if (!ExecutarValidacao(new TicketSorteioValidation(), ticketSorteio))
                return;

            await _ticketSorteioRepository.Atualizar(ticketSorteio);

        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _ticketSorteioRepository.ObterPorId(id);

            if (fornecedor == null)
            {
                Notificar("Sorteio não existe!");
                return;
            }
            await _ticketSorteioRepository.Remover(id);
        }
    }
}

