using Juridico.DTL.Cliente;

namespace Juridico.Application.Cliente.Interfaces
{
    public interface IClienteApp
    {
        Task<List<ClienteDTO>> Listar();
        Task<ClienteDTO> ObterPorId(int id);
        Task<int> Adicionar(ClienteDTO cliente);
        Task Atualizar(ClienteDTO cliente);
        Task Remover(int id);
    }
}
