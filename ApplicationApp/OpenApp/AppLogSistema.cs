using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceLogSistema;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppLogSistema : IInterfaceLogSistemaApp
    {
        private readonly ILogSistema _logSistema;

        public AppLogSistema(ILogSistema logSistema)
        {
            _logSistema = logSistema;
        }

        public async Task Add(LogSistema logSistema)
        {
            await _logSistema.Add(logSistema);
        }

        public async Task Delete(LogSistema logSistema)
        {
            await _logSistema.Delete(logSistema);
        }

        public async Task<LogSistema> GetEntityById(int id)
        {
            return await _logSistema.GetEntityById(id);
        }

        public async Task<List<LogSistema>> List()
        {
            return await _logSistema.List();
        }

        public async Task Update(LogSistema logSistema)
        {
            await _logSistema.Update(logSistema);
        }
    }
}