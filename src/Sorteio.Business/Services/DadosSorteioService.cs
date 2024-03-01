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

        public override Task Atualizar<TV>(DadosSorteio entidade, TV validator)
        {
            var dadoAntigo = _dadosSorteioRepository.ObterPorId(entidade.Id).Result;

            var dadoUpdate = new DadosSorteio
            {
                Id = dadoAntigo.Id,
                Descricao = entidade.Descricao,
                Premio = entidade.Premio,
                ValorPremio =entidade.ValorPremio,
                DataAlteracao = DateTime.Now,
                DataCadastro = dadoAntigo.DataCadastro,
                Ativo = true
            };

            return base.Atualizar(dadoUpdate, validator);
        }


    }
}
