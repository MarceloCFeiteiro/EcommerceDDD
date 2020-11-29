using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppUsuario : IInterfaceUsuarioApp
    {
        private readonly IUsuario _usuario;

        private IServiceUsuario _serviceUsuario;

        public AppUsuario(IUsuario usuario, IServiceUsuario serviceUsuario)
        {
            _usuario = usuario;
            _serviceUsuario = serviceUsuario;
        }

        public async Task Add(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizarTipoUsuario(string userId, TipoUsuario tipoUsuario)
        {
            await _usuario.AtualizarTipoUsuario(userId, tipoUsuario);
        }

        public async Task Delete(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> List()
        {
            return await _usuario.List();
        }

        public async Task<List<ApplicationUser>> ListarUsuariosSomenteParaAdministradores(string userId)
        {
            return await _serviceUsuario.ListarUsuariosSomenteParaAdministradores(userId);
        }

        public async Task<ApplicationUser> ObterUsuarioPeloId(string userId)
        {
            return await _usuario.ObterUsuarioPeloId(userId);
        }

        public async Task Update(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }
    }
}