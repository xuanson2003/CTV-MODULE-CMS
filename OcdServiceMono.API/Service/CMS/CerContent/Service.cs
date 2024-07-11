using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace OcdServiceMono.API.Service.CMS.CerContent
{
    public class Service : RepositoryBase<Models.Entities.CMS.CMS_Cer_Content>, CMS.CerContent.IService
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
        public async Task<List<Models.Entities.CMS.CMS_Cer_Content>> GetAllCerContent()
        {
            return await _readDbContext.CMS_Cer_Content.ToListAsync();
        }

        public async Task<Models.Entities.CMS.CMS_Cer_Content> CreateCerContent(Models.Entities.CMS.CMS_Cer_Content model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.CMS_Cer_Content.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
