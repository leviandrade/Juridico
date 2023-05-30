using Juridico.Domain.Ficha.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Juridico.Infra.Data.Mappings.Ficha
{
    internal sealed class FichaArquivoMapping : IEntityTypeConfiguration<FichaArquivoEntity>
    {
        public void Configure(EntityTypeBuilder<FichaArquivoEntity> builder)
        {
            builder.ToTable("TB_FICHA_ARQUIVO");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_FICHA_ARQUIVO");
            builder.Property(p => p.IdFicha).HasColumnName("ID_FICHA");
            builder.Property(p => p.Arquivo).HasColumnName("ARQUIVO");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
        }
    }
}