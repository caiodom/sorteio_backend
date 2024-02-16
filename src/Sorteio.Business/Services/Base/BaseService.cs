using FluentValidation;
using FluentValidation.Results;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Interfaces.Base;
using Sorteio.Business.Interfaces.Repository;
using Sorteio.Business.Models;
using Sorteio.Business.Models.Base;
using Sorteio.Business.Models.Validations;
using Sorteio.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Services.Base
{
    public abstract class BaseService<TEntity> :IService<TEntity>   where TEntity : Entity,new()
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

        public virtual async Task Adicionar<TV>(TEntity entidade,TV validator) where TV :AbstractValidator<TEntity>
        { 
            if (!ExecutarValidacao(validator, entidade))
                return;

            var dadoExistente = _repository.ObterPorId(entidade.Id);

            if (dadoExistente != null)
            {
                Notificar("Já existe um dado com o ID informado!");
                return;
            }

            await _repository.Adicionar(entidade);
        }

        public virtual async Task Atualizar<TV>(TEntity entidade, TV validator) where TV : AbstractValidator<TEntity>
        {
            if (!ExecutarValidacao(validator, entidade))
                return;

            await _repository.Atualizar(entidade);
        }

        public virtual async Task Remover(Guid id)
        {
            var entidade = await _repository.ObterPorId(id);

            if (entidade == null)
            {
                Notificar("Dado inexistente para remoção !");
                return;
            }

            entidade.Ativo = false;
            entidade.DataAlteracao = DateTime.Now;


            await _repository.Atualizar(entidade);
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}

    

