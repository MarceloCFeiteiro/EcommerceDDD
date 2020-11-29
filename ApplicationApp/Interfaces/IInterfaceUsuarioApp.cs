using Entities.Entities;
using Entities.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface IInterfaceUsuarioApp : IInterfaceGenericApp<ApplicationUser>
    {
        Task AtualizarTipoUsuario(string userId, TipoUsuario tipoUsuario);

        Task<ApplicationUser> ObterUsuarioPeloId(string userId);

        Task<List<ApplicationUser>> ListarUsuariosSomenteParaAdministradores(string userId);
    }
}