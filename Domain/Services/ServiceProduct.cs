using Domain.Interfaces.InterfaceProducts;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _product;

        public ServiceProduct(IProduct product)
        {
            this._product = product;
        }

        public async Task AddProduct(Produto produto)
        {
            bool valido = ValidarProduto(produto);

            if (valido)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _product.Add(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutosComEstoque(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return await _product.ListarProdutos(p => p.QtdEstoque > 0);
            else
            {
                return await _product.ListarProdutos(p => p.QtdEstoque > 0 &&
                                                          p.Nome.ToUpper().Contains(descricao.ToUpper()));
            }
        }

        public async Task UpdateProduct(Produto produto)
        {
            bool valido = ValidarProduto(produto);

            if (valido)
            {
                produto.DataAlteracao = DateTime.Now;
                await _product.Update(produto);
            }
        }

        private bool ValidarProduto(Produto produto)
        {
            return produto.ValidaPropriedadeString(produto.Nome, "Nome")
                & produto.ValidaPropriedadeDecimal(produto.Valor, "Valor")
                & produto.ValidaPropriedadeInt(produto.QtdEstoque, "QtdEstoque");
        }
    }
}