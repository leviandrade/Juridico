using Juridico.Domain.Cliente.Entities;
using Juridico.Domain.Core.Entities;
using Juridico.Domain.Ficha.Entities;
using Juridico.Domain.Interfaces;
using Juridico.Domain.Seguranca.Entities;
using Juridico.Infra.Data.Mappings.Cliente;
using Juridico.Infra.Data.Mappings.Core;
using Juridico.Infra.Data.Mappings.Ficha;
using Juridico.Infra.Data.Mappings.Seguranca;
using Microsoft.EntityFrameworkCore;

namespace Juridico.Infra.Data.Contexts
{
    public sealed class JuridicoContext : DbContext, IUnitOfWork<JuridicoContext>
    {
        public JuridicoContext(DbContextOptions<JuridicoContext> options) : base(options)
        {

        }

        #region Cliente
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<ClienteArquivoEntity> ClienteArquivo { get; set; }

        #endregion

        #region Ficha
        public DbSet<FichaEntity> Ficha { get; set; }
        public DbSet<FichaArquivoEntity> FichaArquivo { get; set; }

        #endregion

        #region Seguranca
        public DbSet<LoginEntity> Login { get; set; }

        #endregion

        #region Core
        public DbSet<EstadoCivilEntity> EstadoCivil { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Cliente

            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ClienteArquivoMapping());
            #endregion

            #region Ficha

            modelBuilder.ApplyConfiguration(new FichaMapping());
            modelBuilder.ApplyConfiguration(new FichaArquivoMapping());

            #endregion

            #region Seguranca

            modelBuilder.ApplyConfiguration(new LoginMapping());

            #endregion

            #region Core

            modelBuilder.ApplyConfiguration(new EstadoCivilMapping());

            #endregion

            base.OnModelCreating(modelBuilder);
        }
        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
