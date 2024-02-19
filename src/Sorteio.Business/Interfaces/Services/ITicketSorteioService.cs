using Sorteio.Business.Interfaces.Base;
using Sorteio.Business.Models;
using Sorteio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Interfaces.Services
{
    public interface ITicketSorteioService : IService<TicketSorteio>
    {
        TicketSorteio Sortear(Guid idDadosSorteio);
    }
}
