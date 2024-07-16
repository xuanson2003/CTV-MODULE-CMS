using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Models.Entities.SM.SM_Menu> UpdateMenu(Guid id, Models.Entities.SM.SM_Menu updatedModel)
        {
            var Menu = await _writeDbContext.SM_Menu.FindAsync(id);
            if (Menu == null)
            {
                // Handle the case where the menu with the given ID does not exist
                throw new KeyNotFoundException("Menu not found");
            }

            // Update the properties
            Menu.Url = updatedModel.Url;
            Menu.Name = updatedModel.Name;
            Menu.ParentId = updatedModel.ParentId;

            if (updatedModel.ParentId != null)
            {

                var MenuPR = await _writeDbContext.SM_Menu.FindAsync(updatedModel.ParentId);
                if (MenuPR == null)
                {
                    throw new KeyNotFoundException("Menu ParentID not found");
                }

                MenuPR.ParentId = updatedModel.ParentId;

            }

            Menu.Order = updatedModel.Order;
            Menu.Icon = updatedModel.Icon;
            Menu.Type = updatedModel.Type;
            Menu.Active = updatedModel.Active;

            await _writeDbContext.SaveChangesAsync();
            return Menu;
        }

        // xóa 
        public async Task<Models.Entities.SM.SM_Menu> DeleteMenu(Guid id)
        {
            var menu = await _writeDbContext.SM_Menu.FirstOrDefaultAsync(m => m.Id == id && m.DeleteAt == null);
            if (menu != null)
            {
                menu.DeleteAt = DateTime.UtcNow;
                await _writeDbContext.SaveChangesAsync();
            }
            return menu;
        }
        public async Task<List<Models.Entities.SM.SM_Menu>> GetMenus()
        {
            return await _writeDbContext.SM_Menu.Where(m => m.DeleteAt == null).ToListAsync();
        }









    }
}
