namespace Juridico.DTL.Cliente
{
    public class ClienteArquivoDTO 
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Arquivo { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
