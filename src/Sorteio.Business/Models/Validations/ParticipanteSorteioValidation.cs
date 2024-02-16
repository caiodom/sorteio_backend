using FluentValidation;
using Sorteio.Business.Models.Validations.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models.Validations
{
    public class ParticipanteSorteioValidation : AbstractValidator<ParticipanteSorteio>
    {
        public ParticipanteSorteioValidation()
        {
            RuleFor(c => c.Nome)
              .NotEmpty()
              .WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 100)
              .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Email)
              .NotEmpty()
              .WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 100)
              .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Telefone)
              .NotEmpty()
              .WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 50)
              .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Telefone)
              .NotEmpty()
              .WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 50)
              .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c=>c.CPF)
              .NotEmpty()
              .WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 50)
              .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(f => f.CPF.Length)
                .Equal(ValidacaoCpf.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(f => ValidacaoCpf.Validar(f.CPF)).Equal(true)
                             .WithMessage("O CPF fornecido é inválido.");
        }

    }
}
