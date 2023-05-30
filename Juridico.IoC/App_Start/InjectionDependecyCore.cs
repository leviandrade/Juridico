using Juridico.Application.Cliente;
using Juridico.Application.Cliente.Interfaces;
using Juridico.Application.Core;
using Juridico.Application.Core.Interfaces;
using Juridico.Application.Ficha;
using Juridico.Application.Ficha.Interfaces;
using Juridico.Application.Seguranca;
using Juridico.Application.Seguranca.Interfaces;
using Juridico.Domain.Cliente.Repositories;
using Juridico.Domain.Core.Repositories;
using Juridico.Domain.Ficha.Repositories;
using Juridico.Domain.Interfaces;
using Juridico.Domain.Notificacoes;
using Juridico.Domain.Seguranca.Repositories;
using Juridico.Infra.Data.Contexts;
using Juridico.Infra.Data.Repositories.Cliente;
using Juridico.Infra.Data.Repositories.Core;
using Juridico.Infra.Data.Repositories.Ficha;
using Juridico.Infra.Data.Repositories.Seguranca;
using Microsoft.Extensions.DependencyInjection;

namespace Juridico.IoC.App_Start
{
    public static class InjectionDependencyCore
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            AddRepositories(services);
            AddApplication(services);

            services.AddScoped<INotificador, Notificador>();
        }

        private static void AddApplication(IServiceCollection services)
        {
            #region Cliente

            services.AddScoped<IClienteApp, ClienteApp>();

            #endregion

            #region Ficha

            services.AddScoped<IFichaApp, FichaApp>();

            #endregion

            #region Seguranca

            services.AddScoped<ILoginApp, LoginApp>();

            #endregion

            #region Core

            services.AddScoped<IEstadoCivilApp, EstadoCivilApp>();

            #endregion

        }

        private static void AddRepositories(IServiceCollection services)
        {
            #region Cliente

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteArquivoRepository, ClienteArquivoRepository>();

            #endregion

            #region Ficha

            services.AddScoped<IFichaRepository, FichaRepository>();
            services.AddScoped<IFichaArquivoRepository, FichaArquivoRepository>();

            #endregion

            #region Seguranca

            services.AddScoped<ILoginRepository, LoginRepository>();

            #endregion

            #region Core

            services.AddScoped<IEstadoCivilRepository, EstadoCivilRepository>();

            #endregion

            services.AddScoped<IUnitOfWork<JuridicoContext>, UnitOfWork<JuridicoContext>>();
        }
    }
}
