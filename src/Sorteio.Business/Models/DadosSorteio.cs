using Sorteio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models
{
    public class DadosSorteio:Entity
    {
        public string Descricao { get; set; }
        public string Premio { get; set; }
        public decimal ValorPremio { get; set; }

        /* EF Relation */
        public ICollection<TicketSorteio> TicketSorteios { get; set; }

    }
}
