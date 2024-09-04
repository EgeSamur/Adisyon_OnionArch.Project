using Adisyon_OnionArch.Project.Application.Interfaces.Repositories;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Persistance.Context;
using Adisyon_OnionArch.Project.Persistance.Repositories;

namespace Adisyon_OnionArch.Project.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ValueTask DisposeAsync()
        {
            return _appDbContext.DisposeAsync();
        }

        public int Save()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
        {
            return new ReadRepository<T>(_appDbContext);
        }

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(_appDbContext);
        }
    }
}
