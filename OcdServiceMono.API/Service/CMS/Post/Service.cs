using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.CMS.Post
{
    public class Service : RepositoryBase<Models.Entities.CMS.CMS_Posts>, CMS.Post.IService
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
        public async Task<List<Models.Entities.CMS.CMS_Posts>> GetAllPost()
        {
            return await _readDbContext.CMS_Posts.ToListAsync();
        }

        public async Task<Models.Entities.CMS.CMS_Posts> CreatePost(Models.Entities.CMS.CMS_Posts model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.CMS_Posts.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<List<Models.Entities.CMS.CMS_Posts>> GetEntitiesTopPostAsync()
        {
            return await _readDbContext.CMS_Posts
                .Where(post => post.IsHot)
                .OrderByDescending(post => post.View)
                .Take(4)
                .ToListAsync();
        }
        public async Task<List<Models.Entities.CMS.CMS_Posts>> GetEntitiesNewsPostAsync()
        {
            return await _readDbContext.CMS_Posts
            .OrderByDescending(post => post.CreatedBy)
            .Take(3)
            .ToListAsync();
        }

        // update
        public async Task<Models.Entities.CMS.CMS_Posts> UpdatePost(Guid id, Models.Entities.CMS.CMS_Posts updatedModel)
        {
            var Posts = await _writeDbContext.CMS_Posts.FindAsync(id);
            if (Posts == null)
            {

                throw new KeyNotFoundException("Posts not found");
            }
            Posts.Title = updatedModel.Title;
            Posts.Desc = updatedModel.Desc;
            Posts.Content = updatedModel.Content;
            Posts.Avatar = updatedModel.Avatar;
            Posts.View = updatedModel.View;
            Posts.IsHot = updatedModel.IsHot;
            Posts.Source = updatedModel.Source;
            Posts.IsActive = updatedModel.IsActive;
            Posts.Avatar = updatedModel.Avatar;
            Posts.Status = updatedModel.Status;
          

            // update khóa ngoại 

            await _writeDbContext.SaveChangesAsync();
            return Posts;
        }
    }
}
