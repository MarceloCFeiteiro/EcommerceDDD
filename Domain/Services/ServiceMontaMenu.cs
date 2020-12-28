using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceMontaMenu : IServiceMontaMenu
    {
        private readonly IUsuario _usuario;

        public ServiceMontaMenu(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public async Task<List<MenuSite>> MontaMenuPorPerfil(string userId)
        {
            var retorno = new List<MenuSite>();

            retorno.Add(new MenuSite { Controller = "Home", Action = "Index", Descricao = "Loja Virtual" });

            if (!string.IsNullOrWhiteSpace(userId))
            {
                retorno.Add(new MenuSite { Controller = "Produtos", Action = "Index", Descricao = "Meus Produtos" });
                retorno.Add(new MenuSite { Controller = "CompraUsuario", Action = "MinhasCompras", Descricao = "MinhasCompras" });

                var usuario = await _usuario.ObterUsuarioPeloId(userId);

                if (usuario != null && usuario.Tipo != null)
                {
                    switch ((TipoUsuario)usuario.Tipo)
                    {
                        case TipoUsuario.Administrador:
                            retorno.Add(new MenuSite { Controller = "LogSistemas", Action = "Index", Descricao = "Logs" });
                            retorno.Add(new MenuSite { Controller = "Usuarios", Action = "ListarUsuarios", Descricao = "Usuários" });
                            break;

                        case TipoUsuario.Comum:
                            break;

                        default:
                            break;
                    }
                }

                retorno.Add(new MenuSite { Controller = "Produtos", Action = "ListarProdutosCarrinhoUsuario", Descricao = "", UrlImagem = "../Img/carrinho.png" });
            }

            return retorno;
        }
    }
}