using Domain.Interfaces.InterfaceCompra;
using Entities.Entities;
using Entities.Entities.Enums;
using InfraStructure.Configuration;
using InfraStructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Repositories
{
    public class RepositoryCompra : RepositoryGenerics<Compra>, ICompra
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryCompra()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<Compra> CompraPorEstado(string userId, EnumEstadoCompra estado)
        {
            using (var banco  =new ContextBase(_optionsBuilder))
            {
                return await banco.Compras.FirstOrDefaultAsync(c => c.UserId == userId && c.Estado == estado);
            }
        }
    }
}
