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
    public class LogSistemasController : BaseController
    {
        public LogSistemasController(ILogger<BaseController> logger,
                   UserManager<ApplicationUser> userManager,
                   IInterfaceLogSistemaApp interfaceLogSistemaApp) : base(logger, userManager, interfaceLogSistemaApp)
        {
        }

        // GET: LogSistemas
        public async Task<IActionResult> Index()
        {
            if (!await UsuarioAdministrador())
                return RedirectToAction("Index", "Home");

            return View(await _interfaceLogSistemaApp.List());
        }

        // GET: LogSistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!await UsuarioAdministrador())
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var logSistema = await _interfaceLogSistemaApp.GetEntityById((int)id);

            if (logSistema == null)
            {
                return NotFound();
            }

            return View(logSistema);
        }
    }
}