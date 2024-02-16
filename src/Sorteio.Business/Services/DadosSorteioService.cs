using Sorteio.Business.Interfaces;
using Sorteio.Business.Interfaces.Repository;
using Sorteio.Business.Interfaces.Services;
using Sorteio.Business.Models;
using Sorteio.Business.Models.Validations;
using Sorteio.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Services
{
    public class DadosSorteioService : BaseService<DadosSorteio>, IDadosSorteioService
    {
        private readonly IDadosSorteioRepository _dadosSorteioRepository;

        public DadosSorteioService(IDadosSorteioRepository dadosSorteioRepository,INotificador notificador) : base(dadosSorteioRepository,notificador)
        {
            _dadosSorteioRepository = dadosSorteioRepository;
        }


        public async Task Adicionar(DadosSorteio dadosSorteio)
        {
            if (!ExecutarValidacao(new DadosSorteioValidation(), dadosSorteio))
                return;

            var  dadoExistente=_dadosSorteioRepository.ObterPorId(dadosSorteio.Id);

            if (dadoExistente != null)
            {
                Notificar("Já existe um sorteio com o ID informado!");
                return;
            }

            await _dadosSorteioRepository.Adicionar(dadosSorteio);
        }


        public async Task Atualizar(DadosSorteio dadosSorteio) 
        {
            if (!ExecutarValidacao(new DadosSorteioValidation(), dadosSorteio)) 
                    return;

            await _dadosSorteioRepository.Atualizar(dadosSorteio);

        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _dadosSorteioRepository.ObterPorId(id);

            if (fornecedor == null)
            {
                Notificar("Sorteio não existe!");
                return;
            }
            await _dadosSorteioRepository.Remover(id);
        }
    }
}
