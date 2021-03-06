﻿using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceCompra;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppCompra : IInterfaceCompraApp
    {
        private readonly ICompra _compra;

        public AppCompra(ICompra ICompra)
        {
            _compra = ICompra;
        }

        public async Task Add(Compra compra)
        {
            await _compra.Add(compra);
        }

        public async Task Delete(Compra compra)
        {
            await _compra.Delete(compra);
        }

        public async Task<Compra> GetEntityById(int id)
        {
            return await _compra.GetEntityById(id);
        }

        public async Task<List<Compra>> List()
        {
            return await _compra.List();
        }

        public async Task Update(Compra compra)
        {
            await _compra.Update(compra);
        }
    }
}