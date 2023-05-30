using Juridico.Domain.Cliente.Entities;
using Juridico.Domain.Cliente.Repositories;
using Juridico.Infra.Data.Contexts;

namespace Juridico.Infra.Data.Repositories.Cliente
{
    public sealed class ClienteArquivoRepository : RepositoryBase<ClienteArquivoEntity>, IClienteArquivoRepository
    {
        public ClienteArquivoRepository(JuridicoContext context) : base(context)
        {
        }
    }
}
