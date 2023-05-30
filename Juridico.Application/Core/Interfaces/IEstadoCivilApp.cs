using Juridico.DTL.Core;

namespace Juridico.Application.Core.Interfaces
{
    public interface IEstadoCivilApp
    {
        Task<List<EstadoCivilDTO>> Listar();
    }
}
