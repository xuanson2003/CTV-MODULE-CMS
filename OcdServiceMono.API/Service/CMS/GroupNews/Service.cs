using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography.Pkcs;
using OcdServiceMono.API.Models.Entities.CMS;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Policy;

namespace OcdServiceMono.API.Service.CMS.Group_News
{
    public class Service : RepositoryBase<Models.Entities.CMS.CMS_Group_News>, CMS.Group_News.IService
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
        public async Task<List<Models.Entities.CMS.CMS_Group_News>> GetAllGroupNews()
        {
            return await _readDbContext.CMS_Group_News.ToListAsync();
        }
        //add
        public async Task<Models.Entities.CMS.CMS_Group_News> CreateGroupNews(Models.Entities.CMS.CMS_Group_News model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.CMS_Group_News.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }

        // update
        public async Task<Models.Entities.CMS.CMS_Group_News> UpdateGroupNews(Guid id, Models.Entities.CMS.CMS_Group_News updatedModel)
        {
            var group_News = await _writeDbContext.CMS_Group_News.FindAsync(id);
            if (group_News == null)
            {

                throw new KeyNotFoundException("Group News not found");
            }
            group_News.Name = updatedModel.Name;
            group_News.Url = updatedModel.Url;
            group_News.Descible = updatedModel.Descible;
           
            // ktra xem có truyền vào id cha không => không có thì thôi, có mới update
            if(updatedModel.ParentId != null) 
            {
                
                var group_NewsPR = await _writeDbContext.CMS_Group_News.FindAsync(updatedModel.ParentId);  
                if (group_NewsPR == null) 
                {
                    throw new KeyNotFoundException("Group News ParentID not found");
                }
             
                group_News.ParentId = updatedModel.ParentId;

            }
           
           
            group_News.CreateBy = updatedModel.CreateBy;
            group_News.CreateAt = updatedModel.CreateAt;
            group_News.Order = updatedModel.Order;

            await _writeDbContext.SaveChangesAsync();
            return group_News;
        }

        // laays 6 nhóm tin 
        public async Task<List<CMS_Group_News>> GetTopGroupNewsAsync()
        {
            // Lấy top 6 nhóm tin tức chuyên ngành theo ngày tạo
            var topGroupNews = await _readDbContext.CMS_Group_News.OrderByDescending(g => g.CreateAt).Take(6).ToListAsync();

            // Danh sách kết quả cuối cùng
            var result = new List<CMS_Group_News>();

            // Lặp qua từng nhóm tin tức chuyên ngành để lấy thông tin chi tiết và top 3 bài viết
            foreach (var groupNews in topGroupNews)
            {
                // Lấy top 3 bài viết trong nhóm hiện tại, sắp xếp theo lượt xem giảm dần
                var topPosts = await _readDbContext.CMS_Posts.OrderByDescending(p => p.View)
                    .Join(_readDbContext.CMS_Group_Posts,
                        post => post.Id,
                        group => group.PostId,
                        (post, group) => new {
                            Post = post,
                            Group = group
                        })
                    .Where(x => x.Group.GroupId == groupNews.Id) // Lọc theo nhóm tin tức hiện tại
                    .Select(x => new {
                        Title = x.Post.Title,
                        // url
                      //  Url =x.Group.Url
                    })
                    .Take(3)
                    .ToListAsync();

                // Tạo đối tượng CMS_Group_News cho kết quả
                var groupNewsResult = new CMS_Group_News
                {
                    Id = groupNews.Id,
                    Name = groupNews.Name,
                    Url = groupNews.Url,
                    Descible = groupNews.Descible,
                    ParentId = groupNews.ParentId,
                    CreateBy = groupNews.CreateBy,
                    CreateAt = groupNews.CreateAt,
                    Order = groupNews.Order,
                    TopPosts = topPosts.Select(p => new CMS_Posts
                    {
                        Title = p.Title,
                        //  Url = p.Url
                    })

                };

                // Thêm vào danh sách kết quả
                result.Add(groupNewsResult);
            }

            return result;
        }


    }
}
