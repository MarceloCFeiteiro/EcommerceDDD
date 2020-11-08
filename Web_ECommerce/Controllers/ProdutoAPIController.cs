using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    [Authorize]
    [LogActionFilter]
    public class ProdutoAPIController : BaseController
    {
        public readonly IInterfaceProductApp _interfaceProductApp;

        public readonly IInterfaceCompraUsuarioApp _interfaceCompraUsuarioApp;

        public ProdutoAPIController(IInterfaceProductApp interfaceProductApp
                                  , IInterfaceCompraUsuarioApp interfaceCompraUsuarioApp,
                                    UserManager<ApplicationUser> userManager
                                  , ILogger<ProdutoAPIController> logger
                                  , IInterfaceLogSistemaApp interfaceLogSistemaApp)
            : base(logger, userManager, interfaceLogSistemaApp)
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