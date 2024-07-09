using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.CMS.Post
{
    public class Service : RepositoryBase<Models.Entities.CMS.CMS_Post>, CMS.Post.IService
    {
        private readonly ReadDomainDbContext _readDbContext;
        private readonly WriteDomainDbContext _writeDbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;
        public Service(ReadDomainDbContext readDbContext, WriteDomainDbContext writeDbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService)
            : base(readDbContext, writeDbContext, dateTimeProvider, userService)
        {
            _readDbContext = readDbContext;
            _writeDbContext = writeDbContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;
        }
        public async Task<List<Models.Entities.CMS.CMS_Post>> GetEntitiesTopPostAsync()
        {
            return await _readDbContext.CMS_Posts
                .Where(post => post.IsHot)
                .OrderByDescending(post => post.View)
                .Take(4)
                .ToListAsync();
        }
        public async Task<List<Models.Entities.CMS.CMS_Post>> GetEntitiesNewsPostAsync()
        {
            return await _readDbContext.CMS_Posts
            .OrderByDescending(post => post.CreatedBy)
            .Take(3)
            .ToListAsync();
        }
    }
}
