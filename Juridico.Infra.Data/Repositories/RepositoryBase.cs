using Juridico.Domain.EntidadeBase;
using Juridico.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Juridico.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entidade, new()
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> Listar()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual void Adicionar(TEntity entity)
        {
            typeof(TEntity).GetProperty("DtCadastro")?.SetValue(entity, DateTime.Now);
            _dbSet.Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task Remover(int id)
        {
            _dbSet.Remove(new TEntity { Id = id });
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
