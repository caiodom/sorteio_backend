using Sorteio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models
{
    public class ParticipanteSorteio:Entity
    {
        public string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? CEP { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        /* EF Relation */
        public ICollection<TicketSorteio> TicketSorteios { get; set; }
    }
}
