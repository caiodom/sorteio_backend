using System.ComponentModel.DataAnnotations;

namespace Sorteio.Api.Models
{
    public class HistoricoSorteioViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdTicketSorteio { get; set; }
        public string Descricao { get; set; }
    }
}
