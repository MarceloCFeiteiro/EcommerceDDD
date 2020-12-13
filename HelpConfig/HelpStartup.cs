using ApplicationApp.Interfaces;
using ApplicationApp.OpenApp;
using Domain.Interfaces.Generics;
using Domain.Interfaces.Generics.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceCompra;
using Domain.Interfaces.InterfaceLogSistema;
using Domain.Interfaces.InterfaceProducts;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfacesServices;
using Domain.Interfaces.InterfaceUsuario;
using Domain.Services;
using InfraStructure.Repository.Generics;
using InfraStructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HelpConfig
{
    public static class HelpStartup
    {
        public static void ConfigureSingleton(IServiceCollection services)
        {
            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGenerics<>), typeof(RepositoryGenerics<>));
            services.AddSingleton<IProduct, RepositoryProduto>();
            services.AddSingleton<ICompraUsuario, RepositoryCompraUsuario>();
            services.AddSingleton<ICompra, RepositoryCompra>();
            services.AddSingleton<ILogSistema, RepositoryLogSistema>();
            services.AddSingleton<IUsuario, RepositoryUsuario>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<IInterfaceProductApp, AppProduct>();
            services.AddSingleton<IInterfaceCompraUsuarioApp, AppCompraUsuario>();
            services.AddSingleton<IInterfaceCompraApp, AppCompra>();
            services.AddSingleton<IInterfaceLogSistemaApp, AppLogSistema>();
            services.AddSingleton<IInterfaceUsuarioApp, AppUsuario>();

            // SERVIÇO DOMINIO
            services.AddSingleton<IServiceProduct, ServiceProduct>();
            services.AddSingleton<IServiceCompraUsuario, ServiceCompraUsuario>();
            services.AddSingleton<IServiceUsuario, ServiceUsuario>();
        }
    }
}