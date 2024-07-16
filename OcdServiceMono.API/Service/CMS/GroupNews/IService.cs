using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.CMS.Group_News
{
    public interface IService : IRepositoryBase<Models.Entities.CMS.CMS_Group_News>
    {
        Task<List<Models.Entities.CMS.CMS_Group_News>> GetAllGroupNews();
        Task<Models.Entities.CMS.CMS_Group_News> CreateGroupNews(Models.Entities.CMS.CMS_Group_News model);
        Task<Models.Entities.CMS.CMS_Group_News> UpdateGroupNews(Guid id, Models.Entities.CMS.CMS_Group_News updatedModel);

        Task<List<Models.Entities.CMS.CMS_Group_News>> GetTopGroupNewsAsync();
    }
}
