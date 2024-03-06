using Sorteio.Business.Interfaces.Base;
using Sorteio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Interfaces.Repository
{
    public interface ITicketSorteioRepository:IRepository<TicketSorteio>
    {
        IEnumerable<TicketSorteio> ListarTicketsCompletos();
        IEnumerable<TicketSorteio> ListarTicketsCompletos(Expression<Func<TicketSorteio, bool>> predicate);
    }
}
