using Domain.Interfaces.Generics;
using InfraStructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGenerics<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _optionBuilder;

        public RepositoryGenerics()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T obj)
        {
            using var data = new ContextBase(_optionBuilder);
            await data.Set<T>().AddAsync(obj);
            await data.SaveChangesAsync();
        }

        public async Task Delete(T obj)
        {
            using var data = new ContextBase(_optionBuilder);
            data.Set<T>().Remove(obj);
            await data.SaveChangesAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            using var data = new ContextBase(_optionBuilder);
            return await data.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> List()
        {
            using var data = new ContextBase(_optionBuilder);
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T obj)
        {
            using var data = new ContextBase(_optionBuilder);
            data.Set<T>().Update(obj);
            await data.SaveChangesAsync();
        }

        #region Disposable

        private bool disposed = false;

        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();

            disposed = true;
        }

        #endregion Disposable
    }
}