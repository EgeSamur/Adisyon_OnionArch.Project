using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<IList<T>> UpdateRangeAsync(IList<T> entity);
        Task SoftDeleteRangeAsync(IList<EntityBase> entity);
        Task SoftDeleteAsync(EntityBase entity);
    }
}
