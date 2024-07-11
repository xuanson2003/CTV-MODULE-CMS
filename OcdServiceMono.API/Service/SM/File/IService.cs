using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.File
{
    public interface IService : IRepositoryBase<Models.Entities.SM.SM_File>
    {
        Task<List<Models.Entities.SM.SM_File>> GetAllMenu();
    }
}
