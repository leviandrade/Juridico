using Juridico.Domain.Ficha.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Juridico.Infra.Data.Mappings.Ficha
{
    internal sealed class FichaMapping : IEntityTypeConfiguration<FichaEntity>
    {
        public void Configure(EntityTypeBuilder<FichaEntity> builder)
        {
            builder.ToTable("TB_FICHA");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_FICHA");
            builder.Property(p => p.IdCliente).HasColumnName("ID_CLIENTE");
            builder.Property(p => p.Titulo).HasColumnName("TITULO");
            builder.Property(p => p.Descricao).HasColumnName("DESCRICAO");
            builder.Property(p => p.FlJusticaGratuita).HasColumnName("FL_JUSTICA_GRATUITA");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");

            builder.HasMany(p => p.Arquivos)
                .WithOne()
                .HasForeignKey(p => p.IdFicha);
        }
    }
}