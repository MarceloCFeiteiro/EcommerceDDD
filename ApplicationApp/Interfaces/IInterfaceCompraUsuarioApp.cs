using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface IInterfaceCompraUsuarioApp : IInterfaceGenericApp<CompraUsuario>
    {
        public Task AdicionaProdutoCarrinho(string userId, CompraUsuario compraUsuario);

        public Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

        public Task<CompraUsuario> CarrinhoCompras(string userId);

        public Task<CompraUsuario> ProdutosComprados(string userId, int? idCompra = null);

        public Task<bool> ConfirmaCompraCarrinhoUsuario(string userId);

        public Task<List<CompraUsuario>> MinhasCompras(string userId);
    }
}