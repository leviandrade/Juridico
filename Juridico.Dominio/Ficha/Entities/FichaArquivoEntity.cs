using Juridico.Domain.EntidadeBase;

namespace Juridico.Domain.Ficha.Entities
{
    public class FichaArquivoEntity : Entidade
    {
        public int IdFicha { get; set; }
        public string Arquivo { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
