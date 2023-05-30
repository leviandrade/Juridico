using Juridico.Domain.Ficha.Entities;
using Juridico.Domain.Ficha.Repositories;
using Juridico.Infra.Data.Contexts;

namespace Juridico.Infra.Data.Repositories.Ficha
{
    public sealed class FichaArquivoRepository : RepositoryBase<FichaArquivoEntity>, IFichaArquivoRepository
    {
        public FichaArquivoRepository(JuridicoContext context) : base(context)
        {
        }
    }
}
