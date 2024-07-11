using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.File
{
    public class Service : RepositoryBase<Models.Entities.SM.SM_File>, SM.File.IService
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

        public async Task<List<Models.Entities.SM.SM_File>> GetAllMenu()
        {
            return await _readDbContext.SM_File.ToListAsync();
        }
    }
}
