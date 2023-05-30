namespace Juridico.Domain.Seguranca.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> PossuiLogin(string cpf, string senha);
    }
}
