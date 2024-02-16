using FluentValidation;
using Sorteio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Interfaces.Base
{
    public interface IService<TEntity>:IDisposable where TEntity : Entity
    {
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Obter(Expression<Func<TEntity, bool>> predicate);
        Task Adicionar<TV>(TEntity entidade, TV validator) where TV : AbstractValidator<TEntity>;
        Task Atualizar<TV>(TEntity entidade, TV validator) where TV : AbstractValidator<TEntity>;
        Task Remover(Guid id);

    }
}
