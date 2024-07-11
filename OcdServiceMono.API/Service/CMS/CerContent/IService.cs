using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.CMS.CerContent
{
    public interface IService : IRepositoryBase<Models.Entities.CMS.CMS_Cer_Content>
    {
        Task<List<Models.Entities.CMS.CMS_Cer_Content>> GetAllCerContent();
        Task<Models.Entities.CMS.CMS_Cer_Content> CreateCerContent(Models.Entities.CMS.CMS_Cer_Content model);
    }
}
