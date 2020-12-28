using ApplicationApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiSite.Controllers
{
    [Authorize]
    public class ProdutoAPIController : Controller
    {
        public readonly IInterfaceProductApp _interfaceProductApp;

        public readonly IInterfaceCompraUsuarioApp _interfaceCompraUsuarioApp;

        public ProdutoAPIController(IInterfaceProductApp interfaceProductApp, IInterfaceCompraUsuarioApp interfaceCompraUsuarioApp)

        {
            _interfaceProductApp = interfaceProductApp;
            _interfaceCompraUsuarioApp = interfaceCompraUsuarioApp;
        }

        [HttpGet("/api/ListaProdutos")]
        public async Task<JsonResult> ListaProdutos(string descricao)
        {
            return Json(await _interfaceProductApp.ListarProdutosComEstoque(descricao));
        }
    }
}