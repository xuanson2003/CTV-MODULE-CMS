using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.CMS.Post
{
    public interface IService : IRepositoryBase<Models.Entities.CMS.CMS_Post>
    {
		public Task<List<Models.Entities.CMS.CMS_Post>> GetEntitiesPostsAsync();
	}
}
