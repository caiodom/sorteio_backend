﻿using System.ComponentModel.DataAnnotations;

namespace Sorteio.Api.Models
{
    public class DadosSorteioViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Premio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorPremio { get; set; }

    }
}
