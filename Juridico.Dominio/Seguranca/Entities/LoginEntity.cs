using Juridico.Domain.EntidadeBase;

namespace Juridico.Domain.Seguranca.Entities
{
    public class LoginEntity : Entidade
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
    }
}
