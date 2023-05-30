using Juridico.Domain.Seguranca.Repositories;
using Juridico.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Juridico.Infra.Data.Repositories.Seguranca
{
    public sealed class LoginRepository : ILoginRepository
    {
        private readonly JuridicoContext _dbContext;
        public LoginRepository(JuridicoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> PossuiLogin(string cpf, string senha)
        {
            return await _dbContext.Login
                                   .AnyAsync(p => p.CPF == cpf && p.Senha == senha);
        }
    }
}
