using ApplicationApp.Interfaces;
using Domain.Interfaces.Generics.InterfaceCompraUsuario;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppCompraUsuario : IInterfaceCompraUsuarioApp
    {
        private readonly ICompraUsuario _compraUsuario;
        private readonly IServiceCompraUsuario _serviceCompraUsuario;

        public AppCompraUsuario(ICompraUsuario compraUsuario, IServiceCompraUsuario serviceCompraUsuario)
        {
            _compraUsuario = compraUsuario;
            _serviceCompraUsuario = serviceCompraUsuario;
        }

        public async Task Add(CompraUsuario obj)
        {
            await _compraUsuario.Add(obj);
        }

        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _serviceCompraUsuario.CarrinhoCompras(userId);
        }

        public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
        {
            return await _compraUsuario.ConfirmaCompraCarrinhoUsuario(userId);
        }

        public async Task Delete(CompraUsuario obj)
        {
            await _compraUsuario.Delete(obj);
        }

        public async Task<CompraUsuario> GetEntityById(int id)
        {
            return await _compraUsuario.GetEntityById(id);
        }

        public async Task<List<CompraUsuario>> List()
        {
            return await _compraUsuario.List();
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId)
        {
            return await _serviceCompraUsuario.ProdutosComprados(userId);
        }

        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            return await _compraUsuario.QuantidadeProdutoCarrinhoUsuario(userId);
        }

        public async Task Update(CompraUsuario obj)
        {
            await _compraUsuario.Update(obj);
        }
    }
}