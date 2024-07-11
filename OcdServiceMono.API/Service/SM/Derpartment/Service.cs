using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Department
{
    public class Service : RepositoryBase<Models.Entities.SM.SM_Department>, SM.Department.IService
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

        public async Task<List<Models.Entities.SM.SM_Department>> GetAllMenu()
        {
            return await _readDbContext.SM_Department.ToListAsync();
        }
        public async Task<Models.Entities.SM.SM_Department> CreateDepartment(Models.Entities.SM.SM_Department model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.SM_Department.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
