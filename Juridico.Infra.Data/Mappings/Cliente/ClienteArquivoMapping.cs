using Juridico.Domain.Cliente.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Juridico.Infra.Data.Mappings.Cliente
{
    internal sealed class ClienteArquivoMapping : IEntityTypeConfiguration<ClienteArquivoEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteArquivoEntity> builder)
        {
            builder.ToTable("TB_CLIENTE_ARQUIVO");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_CLIENTE_ARQUIVO");
            builder.Property(p => p.IdCliente).HasColumnName("ID_CLIENTE");
            builder.Property(p => p.Arquivo).HasColumnName("ARQUIVO");
            builder.Property(p => p.Descricao).HasColumnName("DESCRICAO");

            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
        }
    }
}