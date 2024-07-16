using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Menu
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_Menu>
    {
        Task<List<Models.Entities.SM.SM_Menu>> GetAllMenu();
        Task<Models.Entities.SM.SM_Menu> CreateMenu(Models.Entities.SM.SM_Menu model);
        Task<Models.Entities.SM.SM_Menu> UpdateMenu(Guid id, Models.Entities.SM.SM_Menu updatedModel);

        Task<Models.Entities.SM.SM_Menu> DeleteMenu(Guid menuId);

    }
}
