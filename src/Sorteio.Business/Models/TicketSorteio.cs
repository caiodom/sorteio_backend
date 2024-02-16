using Sorteio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models
{
    public class TicketSorteio:Entity
    {
        public Guid IdParticipanteSorteio { get; set; }
        public Guid IdDadosSorteio { get; set; }
        public int Numero { get; set; }

        /* EF Relation */
        public ParticipanteSorteio ParticipanteSorteio { get; set; }
        public DadosSorteio DadosSorteio { get; set; }
        public ICollection<HistoricoSorteio> HistoricoSorteios { get; set; }
    }
}
