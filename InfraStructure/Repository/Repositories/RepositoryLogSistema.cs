using Domain.Interfaces.InterfaceLogSistema;
using Entities.Entities;
using InfraStructure.Repository.Generics;

namespace InfraStructure.Repository.Repositories
{
    public class RepositoryLogSistema : RepositoryGenerics<LogSistema>, ILogSistema
    {
    }
}