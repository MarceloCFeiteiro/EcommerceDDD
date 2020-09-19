using Domain.Interfaces.InterfaceProducts;
using Entities.Entities;
using Entities.Entities.Enums;
using InfraStructure.Configuration;
using InfraStructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Repositories
{
    public class RepositoryProduto : RepositoryGenerics<Produto>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _optionBuilder;

        public RepositoryProduto()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await banco.Produtos.Where(exProduto).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Produto>> ListarProdutosCarrinhoUsurario(string userId)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                var produtoCarrinhoUsuario = await (from p in banco.Produtos
                                                    join c in banco.CompraUsuarios on p.Id equals c.IdProduto
                                                    where c.UserId.Equals(userId) && c.Estado == EnumEstadoCompra.Produto_Carrinho
                                                    select new Produto
                                                    {
                                                        Id = p.Id,
                                                        Nome = p.Nome,
                                                        Descricao = p.Descricao,
                                                        Observacao = p.Observacao,
                                                        Valor = p.Valor,
                                                        QtdCompra = c.QtdCompra,
                                                        IdProdutoCarrinho = c.Id,
                                                        Url = p.Url
                                                    }).AsNoTracking().ToListAsync();
                return produtoCarrinhoUsuario;
            }
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await banco.Produtos.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                var produtoCarrinhoUsuario = await (from p in banco.Produtos
                                                    join c in banco.CompraUsuarios on p.Id equals c.IdProduto
                                                    where c.Id.Equals(idProdutoCarrinho) && c.Estado == EnumEstadoCompra.Produto_Carrinho
                                                    select new Produto
                                                    {
                                                        Id = p.Id,
                                                        Nome = p.Nome,
                                                        Descricao = p.Descricao,
                                                        Observacao = p.Observacao,
                                                        Valor = p.Valor,
                                                        QtdCompra = c.QtdCompra,
                                                        IdProdutoCarrinho = c.Id,
                                                        Url = p.Url
                                                    }).AsNoTracking().FirstOrDefaultAsync();
                return produtoCarrinhoUsuario;
            }
        }
    }
}