using Juridico.Domain.Cliente.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Juridico.Infra.Data.Mappings.Cliente
{
    internal sealed class ClienteMapping : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("TB_CLIENTE");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_CLIENTE");
            builder.Property(p => p.Nome).HasColumnName("NOME");
            builder.Property(p => p.Rg).HasColumnName("RG");
            builder.Property(p => p.Cpf).HasColumnName("CPF");
            builder.Property(p => p.CEP).HasColumnName("CEP");
            builder.Property(p => p.Endereco).HasColumnName("ENDERECO");
            builder.Property(p => p.Bairro).HasColumnName("BAIRRO");
            builder.Property(p => p.Numero).HasColumnName("NUMERO");
            builder.Property(p => p.Cidade).HasColumnName("CIDADE");
            builder.Property(p => p.Estado).HasColumnName("ESTADO");
            builder.Property(p => p.Complemento).HasColumnName("COMPLEMENTO");
            builder.Property(p => p.Email).HasColumnName("EMAIL");
            builder.Property(p => p.Telefone).HasColumnName("TELEFONE");
            builder.Property(p => p.Profissao).HasColumnName("PROFISSAO");
            builder.Property(p => p.EstadoCivil).HasColumnName("ESTADO_CIVIL");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");

            builder.HasMany(p => p.Arquivos)
                .WithOne()
                .HasForeignKey(p => p.IdCliente);
        }
    }
}