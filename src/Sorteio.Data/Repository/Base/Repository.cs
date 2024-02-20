using Microsoft.EntityFrameworkCore;
using Sorteio.Business.Interfaces.Base;
using Sorteio.Business.Models.Base;
using Sorteio.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Data.Repository.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly SorteioDbContext Db;
        protected readonly DbSet<TEntity> DbSet;


        protected Repository(SorteioDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }


        public virtual async Task<TEntity> ObterPorId(Guid id)
                        => await DbSet.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id && x.Ativo);

        public virtual async Task<List<TEntity>> ObterTodos()
                        => await DbSet.AsNoTracking().Where(x=>x.Ativo).ToListAsync();
     

        public virtual async Task<IEnumerable<TEntity>> Obter(Expression<Func<TEntity, bool>> predicate)
                            => await DbSet.AsNoTracking().Where(predicate).ToListAsync();


        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        //public virtual async Task Remover(Guid id)
        //{
        //    DbSet.Remove(new TEntity { Id = id });
        //    await SaveChanges();
        //}

        public async Task<int> SaveChanges()
            => await Db.SaveChangesAsync();
        

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
