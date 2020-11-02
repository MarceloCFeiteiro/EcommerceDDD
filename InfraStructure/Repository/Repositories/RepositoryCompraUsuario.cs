using Domain.Interfaces.Generics.InterfaceCompraUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using InfraStructure.Configuration;
using InfraStructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Repositories
{
    public class RepositoryCompraUsuario : RepositoryGenerics<CompraUsuario>, ICompraUsuario
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryCompraUsuario()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
        {
            try
            {
                using (var banco = new ContextBase(_optionsBuilder))
                {
                    var compraUsuario = new CompraUsuario();
                    compraUsuario.ListaProdutos = new List<Produto>();

                    var produtosCarrinhoUsuario = await (from p in banco.Produtos
                                                         join c in banco.CompraUsuarios on p.Id equals c.IdProduto
                                                         where c.UserId.Equals(userId) && c.Estado == EnumEstadoCompra.Produto_Carrinho
                                                         select c).AsNoTracking().ToListAsync();

                    produtosCarrinhoUsuario.ForEach(p =>
                    {
                        compraUsuario.IdCompra = p.IdCompra;
                        p.Estado = EnumEstadoCompra.Produto_Comprado;
                    });

                    var compra = await banco.Compras.AsNoTracking().FirstOrDefaultAsync(c => c.Id == compraUsuario.IdCompra);
                    if (compra != null)
                    {
                        compra.Estado = EnumEstadoCompra.Produto_Comprado;
                    }

                    banco.Update(compra);
                    banco.UpdateRange(produtosCarrinhoUsuario);
                    await banco.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CompraUsuario>> MinhasComprasPorEstado(string userId, EnumEstadoCompra estado)
        {
            var retorno = new List<CompraUsuario>();

            using (var banco = new ContextBase(_optionsBuilder))
            {
                var comprasUsuario = await banco.Compras.Where(co => co.UserId.Equals(userId) && co.Estado == estado).ToListAsync();

                foreach (var item in comprasUsuario)
                {
                    var compraUsuario = new CompraUsuario();

                    compraUsuario.ListaProdutos = new List<Produto>();

                    var produtosCarrinhoUsuario = await (from p in banco.Produtos
                                                         join cu in banco.CompraUsuarios on p.Id equals cu.IdProduto
                                                         where cu.UserId.Equals(userId) && cu.Estado == estado && cu.IdCompra == item.Id
                                                         select new Produto
                                                         {
                                                             Id = p.Id,
                                                             Nome = p.Nome,
                                                             Descricao = p.Descricao,
                                                             Observacao = p.Observacao,
                                                             Valor = p.Valor,
                                                             QtdCompra = cu.QtdCompra,
                                                             IdProdutoCarrinho = cu.Id,
                                                             Url = p.Url,
                                                             DataCompra = item.DataCompra
                                                         }).AsNoTracking().ToListAsync();

                    compraUsuario.ListaProdutos = produtosCarrinhoUsuario;
                    compraUsuario.ApplicationUser = await banco.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(userId));
                    compraUsuario.QuantidadeProdutos = produtosCarrinhoUsuario.Count();
                    compraUsuario.EnderecoCompleto = string.Concat(compraUsuario.ApplicationUser.Endereco,
                                                               " - ", compraUsuario.ApplicationUser.ComplementoEndereco,
                                                               " -CEP: ", compraUsuario.ApplicationUser.CEP);
                    compraUsuario.ValorTotal = produtosCarrinhoUsuario.Sum(v => v.Valor);
                    compraUsuario.Estado = estado;
                    compraUsuario.Id = item.Id;

                    retorno.Add(compraUsuario);
                }
                return retorno;
            }
        }

        public async Task<CompraUsuario> ProdutosCompradosPorEstado(string userId, EnumEstadoCompra estado, int? idCompra = null)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var compraUsuario = new CompraUsuario();
                compraUsuario.ListaProdutos = new List<Produto>();

                var produtosCarrinhoUsuario = await (from p in banco.Produtos
                                                     join c in banco.CompraUsuarios on p.Id equals c.IdProduto
                                                     join co in banco.Compras on c.IdCompra equals co.Id
                                                     where c.UserId.Equals(userId) && c.Estado == estado
                                                     && co.UserId.Equals(userId) && co.Estado == estado
                                                     && (idCompra == null || co.Id == idCompra)
                                                     select new Produto
                                                     {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdProdutoCarrinho = c.Id,
                                                         Url = p.Url,
                                                         DataCompra = co.DataCompra
                                                     }).AsNoTracking().ToListAsync();

                compraUsuario.ListaProdutos = produtosCarrinhoUsuario;
                compraUsuario.ApplicationUser = await banco.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(userId));
                compraUsuario.QuantidadeProdutos = produtosCarrinhoUsuario.Count();
                compraUsuario.EnderecoCompleto = string.Concat(compraUsuario.ApplicationUser.Endereco,
                                                                " - ", compraUsuario.ApplicationUser.ComplementoEndereco,
                                                                " -CEP: ", compraUsuario.ApplicationUser.CEP);
                compraUsuario.ValorTotal = produtosCarrinhoUsuario.Sum(v => v.Valor);
                compraUsuario.Estado = estado;
                return compraUsuario;
            }
        }

        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.CompraUsuarios.CountAsync(c => c.UserId.Equals(userId) && c.Estado == EnumEstadoCompra.Produto_Carrinho);
            }
        }
    }
}