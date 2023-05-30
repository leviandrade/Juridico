namespace Juridico.Domain.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        Task CommitAsync();
    }
}
