﻿using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.Entities.Enums;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceUsuario
{
    public interface IUsuario : IGenerics<ApplicationUser>
    {
        Task AtualizarTipoUsuario(string userId, TipoUsuario tipoUsuario);

        Task<ApplicationUser> ObterUsuarioPeloId(string userId);
    }
}