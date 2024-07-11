using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Accounts
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_Accounts>
    {
        Task<List<Models.Entities.SM.SM_Accounts>> GetAllMenu();
        Task<Models.Entities.SM.SM_Accounts> CreateAcc(Models.Entities.SM.SM_Accounts model);
    }
}
