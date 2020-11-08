using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    public class BaseController : Controller
    {
        public readonly ILogger<BaseController> _logger;

        public readonly UserManager<ApplicationUser> _userManager;

        public readonly IInterfaceLogSistemaApp _interfaceLogSistemaApp;

        public BaseController(ILogger<BaseController> logger, UserManager<ApplicationUser> userManager, IInterfaceLogSistemaApp interfaceLogSistemaApp)
        {
            _logger = logger;
            _userManager = userManager;
            _interfaceLogSistemaApp = interfaceLogSistemaApp;
        }

        public async Task<string> RetornarIdUsuarioLogado()
        {
            var idUsuario = await _userManager.GetUserAsync(User);
            return idUsuario.Id;
        }

        public async Task LogEcommerce(EnumTipoLog enumTipoLog, Object obj)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            await _interfaceLogSistemaApp.Add(new LogSistema
            {
                TipoLog = enumTipoLog,
                JsonInformacao = JsonConvert.SerializeObject(obj),
                UserId = await RetornarIdUsuarioLogado(),
                NomeAction = actionName,
                NomeController = controllerName,
            });
        }
    }
}