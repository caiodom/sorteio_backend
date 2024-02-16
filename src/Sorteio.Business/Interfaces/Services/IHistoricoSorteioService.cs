using Sorteio.Business.Interfaces.Base;
using Sorteio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Interfaces.Services
{
    public interface IHistoricoSorteioService : IService<HistoricoSorteio>
    {
        Task Adicionar(HistoricoSorteio historicoSorteio);
        Task Atualizar(HistoricoSorteio historicoSorteio);
        Task Remover(Guid id);

    }
}
