using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Department
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_Department>
    {
        Task<List<Models.Entities.SM.SM_Department>> GetAllDepartment();
        Task<Models.Entities.SM.SM_Department> CreateDepartment(Models.Entities.SM.SM_Department model);
        Task<Models.Entities.SM.SM_Department> UpdateDepartment(Guid id, Models.Entities.SM.SM_Department updatedModel);
    }
}
