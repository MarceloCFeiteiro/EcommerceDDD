using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface IInterfaceProductApp : IInterfaceGenericApp<Produto>
    {
        Task AddProduct(Produto produto);

        Task UpdateProduct(Produto produto);

        Task<List<Produto>> ListarProdutosUsuario(string userId);

        Task<List<Produto>> ListarProdutosComEstoque(string descricao);

        Task<List<Produto>> ListarProdutosCarrinhoUsurario(string userId);

        Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho);
    }
}