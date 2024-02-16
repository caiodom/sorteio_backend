using FluentValidation;
using FluentValidation.Results;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Models.Base;
using Sorteio.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Services.Base
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;    
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notificar(item.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Manipular(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV,TE>(TV validacao,TE entidade)
                where TV:AbstractValidator<TE>
                where TE:Entity
        {
            var validator=validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);

            return false;
        }
    }
}
