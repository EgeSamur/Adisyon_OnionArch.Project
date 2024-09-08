using Adisyon_OnionArch.Project.Application.Interfaces.Repositories;
using Adisyon_OnionArch.Project.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Adisyon_OnionArch.Project.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _dbContext;

        public WriteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> __table { get => _dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await __table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await __table.AddRangeAsync(entities);

        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { __table.Update(entity); });
            return entity;
        }

        public async Task<IList<T>> UpdateRangeAsync(IList<T> entity)
        {
            await Task.Run(() =>
            {
                __table.UpdateRange(entity);
            });
            return entity;
        }

        public async Task SoftDeleteAsync(EntityBase entity)
        {
            if (!entity.DeletedDate.HasValue && entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.UtcNow;
                T entity2 = entity as T;
                __table.Update(entity2);
            }

        }

        public Task SoftDeleteRangeAsync(IList<EntityBase> entities)
        {
            foreach (var entity in entities)
            {
                if (!entity.DeletedDate.HasValue && entity != null)
                {
                    entity.IsDeleted = true;
                    entity.DeletedDate = DateTime.UtcNow;
                    T entity2 = entity as T;
                    __table.Update(entity2);
                }
            }

            return Task.CompletedTask;
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(()=> { __table.RemoveRange(entity); });
        }
    }
}
