using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using InfraStructure.Configuration;
using InfraStructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Repositories
{
    public class RepositoryUsuario : RepositoryGenerics<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryUsuario()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task AtualizarTipoUsuario(string userId, TipoUsuario tipoUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var usuario = await banco.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(userId));

                if (usuario != null)
                {
                    usuario.Tipo = tipoUsuario;
                    banco.Usuarios.Update(usuario);
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<ApplicationUser> ObterUsuarioPeloId(string userId)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            }
        }
    }
}