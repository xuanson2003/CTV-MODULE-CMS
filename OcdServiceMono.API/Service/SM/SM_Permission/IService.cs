using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Permission
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_Permission>
    {
        Task<List<Models.Entities.SM.SM_Permission>> GetAllPermisstion();
        Task<Models.Entities.SM.SM_Permission> CreatePermission(Models.Entities.SM.SM_Permission model);

        Task<Models.Entities.SM.SM_Permission> UpdatePermission(Guid id, Models.Entities.SM.SM_Permission updatedModel);
    }
}
