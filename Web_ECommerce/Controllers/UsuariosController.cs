using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    [Authorize]
    [LogActionFilter]
    public class UsuariosController : BaseController
    {
        private readonly IInterfaceUsuarioApp _interfaceUsuarioApp;

        public UsuariosController(UserManager<ApplicationUser> userManager,
            ILogger<UsuariosController> logger,
            IWebHostEnvironment environment,
            IInterfaceLogSistemaApp interfaceLogSistemaApp,
            IInterfaceUsuarioApp interfaceUsuarioApp) : base(logger, userManager, interfaceLogSistemaApp)
        {
            _interfaceUsuarioApp = interfaceUsuarioApp;
        }

        public async Task<IActionResult> ListarUsuarios()
        {
            return View(await _interfaceUsuarioApp.ListarUsuariosSomenteParaAdministradores(await RetornarIdUsuarioLogado()));
        }

        //GET
        public async Task<IActionResult> Edit(string id)
        {
            var tipoUsuarios = new List<SelectListItem>();

            tipoUsuarios.Add(new SelectListItem { Text = Enum.GetName(typeof(TipoUsuario), TipoUsuario.Comum), Value = Convert.ToInt32(TipoUsuario.Comum).ToString() });
            tipoUsuarios.Add(new SelectListItem { Text = Enum.GetName(typeof(TipoUsuario), TipoUsuario.Administrador), Value = Convert.ToInt32(TipoUsuario.Administrador).ToString() });

            ViewBag.TipoUsuarios = tipoUsuarios;

            return View(await _interfaceUsuarioApp.ObterUsuarioPeloId(id));
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationUser usuario)
        {
            try
            {
                await _interfaceUsuarioApp.AtualizarTipoUsuario(usuario.Id, (TipoUsuario)usuario.Tipo);

                await LogEcommerce(EnumTipoLog.Informativo, usuario);

                return RedirectToAction(nameof(ListarUsuarios));
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);
                return View("Edit", usuario);
            }
        }
    }
}