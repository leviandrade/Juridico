using Juridico.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Juridico.Infra.Data.Contexts
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
