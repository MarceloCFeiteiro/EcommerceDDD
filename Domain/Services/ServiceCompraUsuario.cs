using Domain.Interfaces.Generics.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceCompra;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Entities.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCompraUsuario : IServiceCompraUsuario
    {
        private readonly ICompraUsuario _compraUsuario;

        private readonly ICompra _compra;

        public ServiceCompraUsuario(ICompraUsuario compraUsuario, ICompra compra)
        {
            _compraUsuario = compraUsuario;
            _compra = compra;
        }

        public async Task AdicionarProdutoCarrinho(string userId, CompraUsuario compraUsuario)
        {
            var compra = await _compra.CompraPorEstado(userId, EnumEstadoCompra.Produto_Carrinho);
            if (compra is null)
            {
                compra = new Compra
                {
                    UserId = userId,
                    Estado = EnumEstadoCompra.Produto_Carrinho
                };
                await _compra.Add(compra);
            }

            if (compra.Id > 0)
            {
                compraUsuario.IdCompra = compra.Id;
                await _compraUsuario.Add(compraUsuario);
            }
        }

        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _compraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Carrinho);
        }

        public async Task<List<CompraUsuario>> MinhasCompras(string userId)
        {
            return await _compraUsuario.MinhasComprasPorEstado(userId, EnumEstadoCompra.Produto_Comprado);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId, int? idCompra = null)
        {
            return await _compraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Comprado, idCompra);
        }
    }
}