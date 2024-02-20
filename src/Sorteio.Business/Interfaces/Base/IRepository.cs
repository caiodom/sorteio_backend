using Sorteio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Interfaces.Base
{
    public  interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        //Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Obter(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
