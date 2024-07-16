using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Permission
{
    public class Service : RepositoryBase<Models.Entities.SM.SM_Permission>, SM.Permission.IService
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

        public async Task<List<Models.Entities.SM.SM_Permission>> GetAllPermisstion()
        {
            return await _readDbContext.SM_Permission.ToListAsync();
        }

        public async Task<Models.Entities.SM.SM_Permission> CreatePermission(Models.Entities.SM.SM_Permission model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.SM_Permission.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Models.Entities.SM.SM_Permission> UpdatePermission(Guid id, Models.Entities.SM.SM_Permission updatedModel)
        {
            var Permission = await _writeDbContext.SM_Permission.FindAsync(id);
            if (Permission == null)
            {               
                throw new KeyNotFoundException("Permission not found");
            }
            Permission.Name = updatedModel.Name;
            Permission.Descible = updatedModel.Descible;
            Permission.CreatedAt = updatedModel.CreatedAt;
            Permission.UpdateAt = updatedModel.UpdateAt;

            await _writeDbContext.SaveChangesAsync();
            return Permission;
        }
    }
}
