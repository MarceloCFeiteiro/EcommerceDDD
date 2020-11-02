using ApplicationApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    public class LogSistemasController : Controller
    {
        private readonly IInterfaceLogSistemaApp _interfaceLogSistemaApp;

        public LogSistemasController(IInterfaceLogSistemaApp interfaceLogSistemaAppt)
        {
            _interfaceLogSistemaApp = interfaceLogSistemaAppt;
        }

        // GET: LogSistemas
        public async Task<IActionResult> Index()
        {
            return View(await _interfaceLogSistemaApp.List());
        }

        // GET: LogSistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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