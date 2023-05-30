using Juridico.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Juridico.Infra.Data.Mappings.Core
{
    internal sealed class EstadoCivilMapping : IEntityTypeConfiguration<EstadoCivilEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoCivilEntity> builder)
        {
            builder.ToTable("TB_ESTADO_CIVIL");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_ESTADO_CIVIL");
            builder.Property(p => p.Descricao).HasColumnName("DESCRICAO");
        }
    }
}
