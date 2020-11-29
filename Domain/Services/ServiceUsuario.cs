using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IUsuario _usuario;

        public ServiceUsuario(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public async Task<List<ApplicationUser>> ListarUsuariosSomenteParaAdministradores(string userId)
        {
            var usuario = await _usuario.ObterUsuarioPeloId(userId);

            if (usuario != null && usuario.Tipo == TipoUsuario.Administrador)
            {
                return await _usuario.List();
            }

            return new List<ApplicationUser>();
        }
    }
}