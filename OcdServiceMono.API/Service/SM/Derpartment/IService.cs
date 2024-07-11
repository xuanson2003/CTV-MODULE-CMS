using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Department
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_Department>
    {
        Task<List<Models.Entities.SM.SM_Department>> GetAllMenu();
        Task<Models.Entities.SM.SM_Department> CreateDepartment(Models.Entities.SM.SM_Department model);
    }
}
