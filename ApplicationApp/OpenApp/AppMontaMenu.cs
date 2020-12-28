using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppMontaMenu : IInterfaceMontaMenu
    {
        public readonly IServiceMontaMenu _serviceMontaMenu;

        public AppMontaMenu(IServiceMontaMenu serviceMontaMenu)
        {
            _serviceMontaMenu = serviceMontaMenu;
        }

        public async Task<List<MenuSite>> MontaMenuPorPerfil(string userId)
        {
            return await _serviceMontaMenu.MontaMenuPorPerfil(userId);
        }
    }
}