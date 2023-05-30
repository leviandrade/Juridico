using Juridico.Domain.EntidadeBase;
namespace Juridico.Domain.Cliente.Entities
{
    public class ClienteArquivoEntity : Entidade
    {
        public int IdCliente { get; set; }
        public string Arquivo { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
