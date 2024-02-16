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
    public class ParticipanteSorteioService : BaseService<ParticipanteSorteio>, IParticipanteSorteioService
    {
        private readonly IParticipanteSorteioRepository _participanteSorteioRepository;

        public ParticipanteSorteioService(IParticipanteSorteioRepository participanteSorteioRepository, INotificador notificador) : base(participanteSorteioRepository, notificador)
        {
            _participanteSorteioRepository = participanteSorteioRepository;
        }


        public async Task Adicionar(ParticipanteSorteio participanteSorteio)
        {
            if (!ExecutarValidacao(new ParticipanteSorteioValidation(), participanteSorteio))
                return;

            var dadoExistente = _participanteSorteioRepository.ObterPorId(participanteSorteio.Id);

            if (dadoExistente != null)
            {
                Notificar("Já existe um sorteio com o ID informado!");
                return;
            }

            await _participanteSorteioRepository.Adicionar(participanteSorteio);
        }


        public async Task Atualizar(ParticipanteSorteio participanteSorteio)
        {
            if (!ExecutarValidacao(new ParticipanteSorteioValidation(), participanteSorteio))
                return;

            await _participanteSorteioRepository.Atualizar(participanteSorteio);

        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _participanteSorteioRepository.ObterPorId(id);

            if (fornecedor == null)
            {
                Notificar("Sorteio não existe!");
                return;
            }
            await _participanteSorteioRepository.Remover(id);
        }
    }
}


