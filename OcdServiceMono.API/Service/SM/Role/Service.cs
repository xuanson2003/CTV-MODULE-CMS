using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Role
{
    public class Service : RepositoryBase<Models.Entities.SM.SM_Role>, SM.Role.IService
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

        public async Task<List<Models.Entities.SM.SM_Role>> GetAllRole()
        {
            return await _readDbContext.SM_Role.ToListAsync();
        }

        public async Task<Models.Entities.SM.SM_Role> CreateRole(Models.Entities.SM.SM_Role model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.SM_Role.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
