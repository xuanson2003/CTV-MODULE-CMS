using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        public async Task<Models.Entities.CMS.CMS_Group_News> CreateGroupNews(Models.Entities.CMS.CMS_Group_News model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.CMS_Group_News.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
