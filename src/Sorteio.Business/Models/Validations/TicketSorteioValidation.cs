using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models.Validations
{
    public class TicketSorteioValidation : AbstractValidator<TicketSorteio>
    {

        public TicketSorteioValidation()
        {
            RuleFor(c => c.Numero)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
