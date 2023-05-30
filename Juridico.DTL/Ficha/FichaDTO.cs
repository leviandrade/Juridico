namespace Juridico.DTL.Ficha
{
    public class FichaDTO
    {
        public int Id { get; set; }
        public string IdCliente { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool FlJusticaGratuita { get; set; }
        public DateTime DtCadastro { get; set; }
        public ICollection<FichaArquivoDTO> Arquivos { get; set; }
    }
}
