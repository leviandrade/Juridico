using Juridico.Domain.Core.Entities;

namespace Juridico.Domain.Core.Repositories
{
    public interface IEstadoCivilRepository
    {
        Task<List<EstadoCivilEntity>> Listar();
    }
}
