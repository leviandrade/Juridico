using Juridico.Domain.Cliente.Entities;
using Juridico.Domain.Cliente.Repositories;
using Juridico.Infra.Data.Contexts;

namespace Juridico.Infra.Data.Repositories.Cliente
{
    public sealed class ClienteRepository : RepositoryBase<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(JuridicoContext context) : base(context)
        {
        }
    }
}
