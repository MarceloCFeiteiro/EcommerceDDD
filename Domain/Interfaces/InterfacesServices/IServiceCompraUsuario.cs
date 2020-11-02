using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceCompraUsuario
    {
        public Task AdicionarProdutoCarrinho(string userId, CompraUsuario compraUsuario);

        public Task<CompraUsuario> CarrinhoCompras(string userId);

        public Task<List<CompraUsuario>> MinhasCompras(string userId);

        public Task<CompraUsuario> ProdutosComprados(string userId, int? idCompra = null);
    }
}