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

            _participanteSorteioRepository=participanteSorteioRepository;
        }


        public override Task Atualizar<TV>(ParticipanteSorteio entidade, TV validator)
        {

            var dadoAntigo = _participanteSorteioRepository.ObterPorId(entidade.Id).Result;


            var participanteUpdate = new ParticipanteSorteio
            {
                Id = dadoAntigo.Id,
                Nome = dadoAntigo.Nome,
                Ativo = true,
                DataAlteracao = DateTime.Now,
                Bairro = dadoAntigo.Bairro,
                CEP = dadoAntigo.CEP,
                Cidade = dadoAntigo.Cidade,
                Complemento = dadoAntigo.Complemento,
                CPF = dadoAntigo.CPF,
                DataCadastro = dadoAntigo.DataCadastro,
                Email = dadoAntigo.Email,
                Estado = dadoAntigo.Estado,
                Logradouro = dadoAntigo.Logradouro,
                Numero = dadoAntigo.Numero,
                Telefone = dadoAntigo.Telefone,
            };


            return base.Atualizar(participanteUpdate, validator);

        }
    }
}


