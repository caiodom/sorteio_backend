using Sorteio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models
{
    public class HistoricoSorteio:Entity
    {
        public Guid IdTicketSorteio { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public TicketSorteio TicketSorteio { get; set; }

    }
}
