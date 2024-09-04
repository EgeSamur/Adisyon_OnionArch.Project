using Adisyon_OnionArch.Project.Application.Interfaces.Repositories;
using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
