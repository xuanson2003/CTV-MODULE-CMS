using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.API.Models.Entities.SM;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Service.SM.Menu
{
    public class Service : RepositoryBase<Models.Entities.SM.SM_Menu>, SM.Menu.IService
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

        public async Task<List<SM_Menu>> GetAllMenu()
        {
            var menus = await _readDbContext.SM_Menu
                .Include(m => m.ChildMenus)
                .ToListAsync();

            // Build the hierarchy
            var menuDictionary = menus.ToDictionary(m => m.Id);
            foreach (var menu in menus)
            {
                if (menu.ParentId.HasValue)
                {
                    menuDictionary[menu.ParentId.Value].ChildMenus.Add(menu);
                }
            }

            // Return only top-level menus
            return menus.Where(m => !m.ParentId.HasValue).ToList();
        }


        public async Task<Models.Entities.SM.SM_Menu> CreateMenu(Models.Entities.SM.SM_Menu model)
        {
            model.Id = Guid.NewGuid();
            var result = await _writeDbContext.SM_Menu.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
