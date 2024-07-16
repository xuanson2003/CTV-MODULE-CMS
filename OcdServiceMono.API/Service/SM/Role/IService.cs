using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Role
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_Role>
    {
        Task<List<Models.Entities.SM.SM_Role>> GetAllRole();
        Task<Models.Entities.SM.SM_Role> CreateRole(Models.Entities.SM.SM_Role model);
        Task<Models.Entities.SM.SM_Role> UpdateRole(Guid id, Models.Entities.SM.SM_Role updatedModel);
    }
}
