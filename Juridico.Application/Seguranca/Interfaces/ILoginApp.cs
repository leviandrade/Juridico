namespace Juridico.Application.Seguranca.Interfaces
{
    public interface ILoginApp
    {
        Task<bool> PossuiLogin(string cpf, string senha);
    }
}
