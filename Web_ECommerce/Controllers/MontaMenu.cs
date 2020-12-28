using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    public class MontaMenu : BaseController
    {
        private readonly IInterfaceMontaMenu _interfaceMontaMenu;

        public MontaMenu(ILogger<BaseController> logger,
                         UserManager<ApplicationUser> userManager,
                         IInterfaceLogSistemaApp interfaceLogSistemaApp,
                         IInterfaceMontaMenu interfaceMontaMenu) : base(logger, userManager, interfaceLogSistemaApp)
        {
            _interfaceMontaMenu = interfaceMontaMenu;
        }

        [AllowAnonymous]
        [HttpGet("/api/ListarMenu")]
        public async Task<IActionResult> ListarMenu()
        {
            var listaMenu = new List<MenuSite>();

            var idUsuario = await RetornarIdUsuarioLogado();

            listaMenu = await _interfaceMontaMenu.MontaMenuPorPerfil(idUsuario);

            return Json(new { listaMenu });
        }
    }
}