using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface IInterfaceMontaMenu
    {
        Task<List<MenuSite>> MontaMenuPorPerfil(string userId);
    }
}