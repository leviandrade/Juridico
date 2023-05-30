namespace Juridico.DTL.Cliente
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Rg { get; set; }
        public string Cpf { get; set; }
        public string? CEP { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Complemento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Profissao { get; set; }
        public int? EstadoCivil { get; set; }
        public DateTime DtCadastro { get; set; }

        public ICollection<ClienteArquivoDTO> Arquivos { get; set; }
    }
}
