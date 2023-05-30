using Juridico.Domain.EntidadeBase;

namespace Juridico.Domain.Ficha.Entities
{
    public class FichaEntity : Entidade
    {
        public string IdCliente { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool FlJusticaGratuita { get; set; }
        public DateTime DtCadastro { get; set; }
        public ICollection<FichaArquivoEntity> Arquivos { get; set; }
    }
}
