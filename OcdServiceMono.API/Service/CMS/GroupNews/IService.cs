using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.CMS.Group_News
{
    public interface IService : IRepositoryBase<Models.Entities.CMS.CMS_Group_News>
    {
        Task<List<Models.Entities.CMS.CMS_Group_News>> GetAllGroupNews();
        Task<Models.Entities.CMS.CMS_Group_News> CreateGroupNews(Models.Entities.CMS.CMS_Group_News model);
    }
}
