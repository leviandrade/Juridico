using Juridico.Domain.Ficha.Entities;
using Juridico.Domain.Ficha.Repositories;
using Juridico.Infra.Data.Contexts;

namespace Juridico.Infra.Data.Repositories.Ficha
{
    public sealed class FichaRepository : RepositoryBase<FichaEntity>, IFichaRepository
    {
        public FichaRepository(JuridicoContext context) : base(context)
        {
        }
    }
}
