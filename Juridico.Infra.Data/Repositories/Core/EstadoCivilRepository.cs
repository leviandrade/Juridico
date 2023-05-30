using Juridico.Domain.Core.Entities;
using Juridico.Domain.Core.Repositories;
using Juridico.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Juridico.Infra.Data.Repositories.Core
{
    public sealed class EstadoCivilRepository : IEstadoCivilRepository
    {
        private readonly JuridicoContext _juridicoContext;

        public EstadoCivilRepository(JuridicoContext juridicoContext)
        {
            _juridicoContext = juridicoContext;
        }

        public async Task<List<EstadoCivilEntity>> Listar()
        {
            return await _juridicoContext.EstadoCivil.ToListAsync();
        }
    }
}
