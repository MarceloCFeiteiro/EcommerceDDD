using Domain.Interfaces.InterfaceProducts;
using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Entities.Entities;
using InfraStructure.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestEccomerceDDD
{
    [TestClass]
    public class UnitTestEcommerce
    {
        [TestMethod]
        public async Task AddProdutoComSuceeso()
        {
            try
            {
                IProduct _product = new RepositoryProduto();
                IServiceProduct _serviceProduct = new ServiceProduct(_product);

                var produto = new Produto
                {
                    Descricao = string.Concat("Descri��o teste TDD", DateTime.Now.ToString()),
                    QtdEstoque = 10,
                    Nome = string.Concat("Nome teste TDD", DateTime.Now.ToString()),
                    Valor = 20,
                    UserId = "d4ca1bec-64a9-410f-aa39-2e85b699e7d9"
                };

                await _serviceProduct.AddProduct(produto);

                Assert.IsFalse(produto.Notificacoes.Any(), "Ocorreu um erro e uma notifica��o foi lan�ada.");
            }
            catch (Exception)
            {
                Assert.Fail("O produto n�o pode ser adicionado no banco.");
            }
        }

        [TestMethod]
        public async Task AddProductComValidacaoCamposObrigatorios()
        {
            try
            {
                IProduct _product = new RepositoryProduto();
                IServiceProduct _serviceProduct = new ServiceProduct(_product);

                var produto = new Produto { };

                await _serviceProduct.AddProduct(produto);

                Assert.IsTrue(produto.Notificacoes.Any(), "N�o foi lan�ada uma notifi��o");
            }
            catch (Exception)
            {
                Assert.Fail("O produto pode ser adicionado no banco.");
            }
        }

        [TestMethod]
        public async Task ListarProdutosUsuario()
        {
            try
            {
                IProduct _product = new RepositoryProduto();

                var listaProdutos = await _product.ListarProdutosUsuario("d4ca1bec-64a9-410f-aa39-2e85b699e7d9");

                var u = listaProdutos.Any();

                Assert.IsTrue(listaProdutos.Any(), "N�o existem produtos na base.");
            }
            catch (Exception)
            {
                Assert.Fail("N�o foi possivel listar os produtos.");
            }
        }

        [TestMethod]
        public async Task GetEntityById()
        {
            try
            {
                IProduct _product = new RepositoryProduto();

                var listaProdutos = await _product.ListarProdutosUsuario("d4ca1bec-64a9-410f-aa39-2e85b699e7d9");

                var produto = await _product.GetEntityById(listaProdutos.LastOrDefault().Id);

                Assert.IsTrue(produto != null, "N�o existem produtos na base.");
            }
            catch (Exception)
            {
                Assert.Fail("N�o foi possivel buscar um produto por id.");
            }
        }

        [TestMethod]
        public async Task Delete()
        {
            try
            {
                IProduct _product = new RepositoryProduto();

                var listaProdutos = await _product.ListarProdutosUsuario("d4ca1bec-64a9-410f-aa39-2e85b699e7d9");

                var ultimoProduto = listaProdutos.LastOrDefault();

                await _product.Delete(ultimoProduto);

                Assert.IsTrue(true, "N�o foi poss�vel deletar o produto da base.");
            }
            catch (Exception)
            {
                Assert.Fail("N�o foi poss�vel deletar o produto da base.");
            }
        }
    }
}