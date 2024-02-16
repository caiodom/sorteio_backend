using System.ComponentModel.DataAnnotations;

namespace Sorteio.Api.Models
{
    public class TicketSorteioViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdParticipanteSorteio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdDadosSorteio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero { get; set; }
    }
}
