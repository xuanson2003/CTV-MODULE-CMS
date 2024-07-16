using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Accounts
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_Accounts>
    {
        Task<List<Models.Entities.SM.SM_Accounts>> GetAllAcc();
        Task<Models.Entities.SM.SM_Accounts> CreateAcc(Models.Entities.SM.SM_Accounts model);

        Task<Models.Entities.SM.SM_Accounts> UpdateAcc(Guid id, Models.Entities.SM.SM_Accounts updatedModel);
    }
}
