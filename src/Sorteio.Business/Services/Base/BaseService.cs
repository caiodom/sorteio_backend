using FluentValidation;
using FluentValidation.Results;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Interfaces.Base;
using Sorteio.Business.Models.Base;
using Sorteio.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Services.Base
{
    public abstract class BaseService<TEntity> :IService<TEntity>   where TEntity : Entity
    {
        private readonly INotificador _notificador;
        private readonly IRepository<TEntity> _repository;

        protected BaseService(IRepository<TEntity> repository,INotificador notificador)
        {
            _repository = repository;
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

        public virtual async Task<TEntity> ObterPorId(Guid id)
                                  => await _repository.ObterPorId(id);

        public virtual async Task<List<TEntity>> ObterTodos()
                                    => await _repository.ObterTodos();

        public virtual async Task<IEnumerable<TEntity>> Obter(Expression<Func<TEntity, bool>> predicate)
                                   => await _repository.Obter(predicate);

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
