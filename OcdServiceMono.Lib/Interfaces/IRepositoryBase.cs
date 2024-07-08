using OcdServiceMono.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }

        Task<Paged<TEntity>> GetEntitiesAsync(int page, int pageSize, string searchBy = "", string orderBy = "", string columns = "");
        
        Task<TEntity> GetEntityByIdAsync(Guid id);

        Task<TEntity> SaveEntityAsync(TEntity entity);

        Task<List<TEntity>> SaveEntitiesAsync(List<TEntity> entities);

        Task RemoveSaveEntitiesAsync(List<TEntity> entities);

        Task<TEntity> AddOrEditEntityAsync(TEntity entity);

        void RemoveEntity(TEntity entity);

        void RemoveEntities(List<TEntity> entities);
    }
}
