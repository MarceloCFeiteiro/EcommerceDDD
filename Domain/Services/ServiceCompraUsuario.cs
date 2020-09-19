using Domain.Interfaces.Generics.InterfaceCompraUsuario;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Entities.Entities.Enums;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCompraUsuario : IServiceCompraUsuario
    {
        private readonly ICompraUsuario _compraUsuario;

        public ServiceCompraUsuario(ICompraUsuario compraUsuario)
        {
            _compraUsuario = compraUsuario;
        }

        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _compraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Carrinho);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId)
        {
            return await _compraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Comprado);
        }
    }
}