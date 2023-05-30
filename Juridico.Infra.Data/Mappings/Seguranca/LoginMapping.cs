using Juridico.Domain.Seguranca;
using Juridico.Domain.Seguranca.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Juridico.Infra.Data.Mappings.Seguranca
{
    internal sealed class LoginMapping : IEntityTypeConfiguration<LoginEntity>
    {
        public void Configure(EntityTypeBuilder<LoginEntity> builder)
        {
            builder.ToTable("TB_LOGIN");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_LOGIN");
            builder.Property(p => p.Nome).HasColumnName("NOME");
            builder.Property(p => p.CPF).HasColumnName("CPF");
            builder.Property(p => p.Senha).HasColumnName("SENHA");
        }
    }
}