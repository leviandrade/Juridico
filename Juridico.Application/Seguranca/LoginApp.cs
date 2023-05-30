using Juridico.Application.Seguranca.Interfaces;
using Juridico.Domain.Seguranca.Repositories;
using Juridico.Helpers;

namespace Juridico.Application.Seguranca
{
    public sealed class LoginApp : ILoginApp
    {
        private readonly ILoginRepository _loginRepository;
        public LoginApp(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<bool> PossuiLogin(string cpf, string senha)
        {
            senha = HashHelper.CriptografarTexto(senha);
            return await _loginRepository.PossuiLogin(cpf, senha);
        }
    }
}
