using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models.Validations
{
    public class DadosSorteioValidation:AbstractValidator<DadosSorteio>
    {
        public DadosSorteioValidation()
        {
            RuleFor(x => x.Premio)
                 .NotEmpty()
                 .WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(2, 100)
                 .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.ValorPremio)
             .NotEmpty()
             .GreaterThan(0)
             .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
