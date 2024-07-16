using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.CMS.Post
{
    public interface IService : IRepositoryBase<Models.Entities.CMS.CMS_Posts>
    {
        Task<List<Models.Entities.CMS.CMS_Posts>> GetAllPost();
        Task<Models.Entities.CMS.CMS_Posts> CreatePost(Models.Entities.CMS.CMS_Posts model);
        public Task<List<Models.Entities.CMS.CMS_Posts>> GetEntitiesTopPostAsync();
        public Task<List<Models.Entities.CMS.CMS_Posts>> GetEntitiesNewsPostAsync();
        Task<Models.Entities.CMS.CMS_Posts> UpdatePost(Guid id, Models.Entities.CMS.CMS_Posts updatedModel);
    }
}
