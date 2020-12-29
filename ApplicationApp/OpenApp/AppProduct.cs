using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProducts;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : IInterfaceProductApp
    {
        public readonly IProduct _product;
        public readonly IServiceProduct _serviceProduct;

        public AppProduct(IProduct product, IServiceProduct serviceProduct)
        {
            this._product = product;
            this._serviceProduct = serviceProduct;
        }

        public async Task Add(Produto obj)
        {
            await _product.Add(obj);
        }

        public async Task AddProduct(Produto produto)
        {
            await _serviceProduct.AddProduct(produto);
        }

        public async Task Delete(Produto obj)
        {
            await _product.Delete(obj);
        }

        public async Task<Produto> GetEntityById(int id)
        {
            return await _product.GetEntityById(id);
        }

        public async Task<List<Produto>> List()
        {
            return await _product.List();
        }

        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            return await _product.ListarProdutosCarrinhoUsuario(userId);
        }

        public async Task<List<Produto>> ListarProdutosComEstoque(string descricao)
        {
            return await _serviceProduct.ListarProdutosComEstoque(descricao);
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            return await _product.ListarProdutosUsuario(userId);
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            return await _product.ObterProdutoCarrinho(idProdutoCarrinho);
        }

        public async Task Update(Produto obj)
        {
            await _product.Update(obj);
        }

        public async Task UpdateProduct(Produto produto)
        {
            await _serviceProduct.UpdateProduct(produto);
        }
    }
}