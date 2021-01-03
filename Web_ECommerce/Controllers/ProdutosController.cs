using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    [Authorize]
    [LogActionFilter]
    public class ProdutosController : BaseController
    {
        public readonly IInterfaceProductApp _interfaceProduct;

        public readonly IInterfaceCompraUsuarioApp _interfaceCompraUsuarioApp;

        private readonly IWebHostEnvironment _environment;

        public ProdutosController(IInterfaceProductApp interfaceProduct,
                                  IInterfaceCompraUsuarioApp interfaceCompraUsuarioApp,
                                  IInterfaceLogSistemaApp interfaceLogSistemaApp,
                                  ILogger<BaseController> logger,
                                  UserManager<ApplicationUser> userManager,
                                  IWebHostEnvironment environment) : base(logger, userManager, interfaceLogSistemaApp)
        {
            _interfaceProduct = interfaceProduct;
            _interfaceCompraUsuarioApp = interfaceCompraUsuarioApp;
            _environment = environment;
        }

        // GET: ProdutosController
        public async Task<IActionResult> Index()
        {
            var idUusario = await RetornarIdUsuarioLogado();

            return View(await _interfaceProduct.ListarProdutosUsuario(idUusario));
        }

        // GET: ProdutosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _interfaceProduct.GetEntityById(id));
        }

        // GET: ProdutosController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            try
            {
                var idUusario = await RetornarIdUsuarioLogado();

                produto.UserId = idUusario;

                await _interfaceProduct.AddProduct(produto);

                if (produto.Notificacoes.Any())
                {
                    foreach (var notificacao in produto.Notificacoes)
                    {
                        ModelState.AddModelError(notificacao.NomePropriedade, notificacao.Mensagem);
                    }

                    return View("Create", produto);
                }

                await SalvarImagemDoProduto(produto);
                await LogEcommerce(EnumTipoLog.Informativo, produto);
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);
                return View("Create", produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _interfaceProduct.GetEntityById(id));
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            try
            {
                await _interfaceProduct.UpdateProduct(produto);

                if (produto.Notificacoes.Any())
                {
                    foreach (var notificacao in produto.Notificacoes)
                    {
                        ModelState.AddModelError(notificacao.NomePropriedade, notificacao.Mensagem);
                    }

                    ViewBag.Alerta = true;
                    ViewBag.Mensagem = "Verifique, não foi possível alterar o produto!";

                    return View("Edit", produto);
                }
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);
                return View("Edit", produto);
            }

            await LogEcommerce(EnumTipoLog.Informativo, produto);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _interfaceProduct.GetEntityById(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _interfaceProduct.GetEntityById(id);
                await _interfaceProduct.Delete(produtoDeletar);
                await LogEcommerce(EnumTipoLog.Informativo, produtoDeletar);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);
                return View();
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/ListarProdutosComEstoque")]
        public async Task<JsonResult> ListarProdutosComEstoque(string descricao)
        {
            return Json(await _interfaceProduct.ListarProdutosComEstoque(descricao));
        }

        public async Task<IActionResult> ListarProdutosCarrinhoUsuario()
        {
            var idUusario = await RetornarIdUsuarioLogado();

            return View(await _interfaceProduct.ListarProdutosCarrinhoUsuario(idUusario));
        }

        // GET: ProdutosController/Delete/5
        public async Task<IActionResult> RemoverCarrinho(int id)
        {
            return View(await _interfaceProduct.ObterProdutoCarrinho(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverCarrinho(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _interfaceCompraUsuarioApp.GetEntityById(id);
                await _interfaceCompraUsuarioApp.Delete(produtoDeletar);
                return RedirectToAction(nameof(ListarProdutosCarrinhoUsuario));
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);
                return View();
            }
        }

        public async Task SalvarImagemDoProduto(Produto produtoTela)
        {
            try
            {
                var produto = await _interfaceProduct.GetEntityById(produtoTela.Id);

                if (produtoTela.Imagem != null)
                {
                    var webRoot = _environment.WebRootPath; //root da pasta onde estão as imagens. cai na pasta wwroot
                    var permissionSet = new PermissionSet(PermissionState.Unrestricted);
                    var writePermission = new FileIOPermission(FileIOPermissionAccess.Append, string.Concat(webRoot, "/imgProdutos")); //permissão para o portal salvar as imagens na pasta.
                    permissionSet.AddPermission(writePermission);

                    var Extesion = Path.GetExtension(produtoTela.Imagem.FileName);

                    var NomeArquivo = string.Concat(produto.Id.ToString(), Extesion);

                    var diretorioArquivoSalvar = string.Concat(webRoot, "\\imgProdutos\\", NomeArquivo);

                    produtoTela.Imagem.CopyTo(new FileStream(diretorioArquivoSalvar, FileMode.Create));

                    produto.Url = string.Concat("https://localhost:5001", "/imgProdutos/", NomeArquivo);

                    await _interfaceProduct.UpdateProduct(produto);
                }
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);
            }
        }
    }
}