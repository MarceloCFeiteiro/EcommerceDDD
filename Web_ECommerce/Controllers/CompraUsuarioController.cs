using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web_ECommerce.Models;

namespace Web_ECommerce.Controllers
{
    public class CompraUsuarioController : HelperQrCode
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly IInterfaceCompraUsuarioApp _interfaceCompraUsuarioApp;
        private IWebHostEnvironment _environment;

        public CompraUsuarioController(UserManager<ApplicationUser> userManager, IInterfaceCompraUsuarioApp interfaceCompraUsuarioApp, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _interfaceCompraUsuarioApp = interfaceCompraUsuarioApp;
            _environment = environment;
        }

        public async Task<IActionResult> FinalizarCompra()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var compraUsuario = await _interfaceCompraUsuarioApp.CarrinhoCompras(usuario.Id);
            return View(compraUsuario);
        }

        public async Task<IActionResult> MinhasCompras(bool mensagem = false)
        {
            var usuario = await _userManager.GetUserAsync(User);
            var compraUsuario = await _interfaceCompraUsuarioApp.ProdutosComprados(usuario.Id);

            if (mensagem)
            {
                ViewBag.Sucesso = true;
                ViewBag.Mensagem = "Compra efetvada com sucesso. Pague o boleto para garantir sua compra!";
            }

            return View(compraUsuario);
        }

        public async Task<IActionResult> ConfirmaCompra()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var sucesso = await _interfaceCompraUsuarioApp.ConfirmaCompraCarrinhoUsuario(usuario.Id);

            if (sucesso)
            {
                return RedirectToAction("MinhasCompras", new { mensagem = true });
            }
            else
                return RedirectToAction("FinalizarCompra");
        }

        public async Task<IActionResult> Imprimir()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var compraUsuario = await _interfaceCompraUsuarioApp.ProdutosComprados(usuario.Id);
            return await Download(compraUsuario, _environment);
        }

        [HttpPost("/api/AdicionarProdutoNoCarrinho")]
        public async Task<JsonResult> AdicionarProdutoNoCarrinho(string id, string nome, int qtd)
        {
            var usuario = await _userManager.GetUserAsync(User);

            var IdProduto = Convert.ToInt32(id);

            if (usuario != null)
            {
                await _interfaceCompraUsuarioApp.Add(new CompraUsuario
                {
                    IdProduto = Convert.ToInt32(id),
                    Estado = EnumEstadoCompra.Produto_Carrinho,
                    QtdCompra = Convert.ToInt32(qtd),
                    UserId = usuario.Id
                });

                return Json(new { sucesso = true });
            }
            return Json(new { sucesso = false });
        }

        [HttpGet("/api/QdProdutoCarrinho")]
        public async Task<JsonResult> QdProdutoCarrinho()
        {
            var usuario = await _userManager.GetUserAsync(User);

            int qtd = 0;

            if (usuario != null)
            {
                qtd = await _interfaceCompraUsuarioApp.QuantidadeProdutoCarrinhoUsuario(usuario.Id);
                return Json(new
                {
                    sucesso = true,
                    qtd = qtd
                });
            }

            return Json(new
            {
                sucesso = false,
                qtd = qtd
            });
        }
    }
}