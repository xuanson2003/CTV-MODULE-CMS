using Microsoft.EntityFrameworkCore;
using OcdServiceMono.Lib.Helpers;
using OcdServiceMono.Lib.Interfaces;
using OcdServiceMono.Lib.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using OcdServiceMono.Lib.Common;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using OcdServiceMono.API.Infrastructure.DbContexts;
using System.Collections.Generic;

namespace OcdServiceMono.API.Service
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : AuditEntity
    {
        private readonly ReadDomainDbContext _readDbContext;
        private readonly WriteDomainDbContext _writeDbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _writeDbContext;
            }
        }

        public RepositoryBase(ReadDomainDbContext readDbContext, WriteDomainDbContext writeDbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService)
        {
            _readDbContext = readDbContext;
            _writeDbContext = writeDbContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;
        }

        public async Task<Paged<T>> GetEntitiesAsync(int page, int pageSize, string searchBy, string orderBy, string columns)
        {
            var query = _readDbContext.Set<T>().Select(columns);
            if (!string.IsNullOrEmpty(searchBy))
            {
                query = query.Where(searchBy);
            }
            int countItems = await query.CountAsync();
            Paged<T> paged = new Paged<T>(countItems, page, pageSize);
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }
            paged.Items = await query.Skip(paged.SkipRows).Take(paged.PageSize).ToDynamicListAsync();
            return paged;
        }

        public async Task<T> GetEntityByIdAsync(Guid id)
        {
            return await _readDbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<T> SaveEntityAsync(T entitySave)
        {
            var entityExist = await _writeDbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == entitySave.Id);
            string userName = string.IsNullOrEmpty(_userProvider.UserName) ? "Guest" : _userProvider.UserName;
            if (entityExist != null)
            {
                entitySave.CreatedDateTime = entityExist.CreatedDateTime;
                entitySave.CreatedBy = entityExist.CreatedBy;
                entitySave.UpdatedDateTime = _dateTimeProvider.OffsetNow;
                entitySave.UpdatedBy = userName;
                _writeDbContext.Entry(entityExist).CurrentValues.SetValues(entitySave);
            }
            else
            {
                entitySave.Id = Guid.NewGuid();
                entitySave.CreatedDateTime = _dateTimeProvider.OffsetNow;
                entitySave.CreatedBy = userName;
                entitySave.UpdatedDateTime = null;
                entitySave.UpdatedBy = string.Empty;
                await _writeDbContext.Set<T>().AddAsync(entitySave);
            }
            await UnitOfWork.SaveChangesAsync();
            return entitySave;
        }

        public async Task<List<T>> SaveEntitiesAsync(List<T> entitiesSave)
        {
            foreach (var entitySave in entitiesSave)
            {
                var entityExist = await _writeDbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == entitySave.Id);
                string userName = string.IsNullOrEmpty(_userProvider.UserName) ? "Guest" : _userProvider.UserName;
                if (entityExist != null)
                {
                    entitySave.CreatedDateTime = entityExist.CreatedDateTime;
                    entitySave.CreatedBy = entityExist.CreatedBy;
                    entitySave.UpdatedDateTime = _dateTimeProvider.OffsetNow;
                    entitySave.UpdatedBy = userName;
                    _writeDbContext.Entry(entityExist).CurrentValues.SetValues(entitySave);
                }
                else
                {
                    entitySave.Id = Guid.NewGuid();
                    entitySave.CreatedDateTime = _dateTimeProvider.OffsetNow;
                    entitySave.CreatedBy = userName;
                    entitySave.UpdatedDateTime = null;
                    entitySave.UpdatedBy = string.Empty;
                    await _writeDbContext.Set<T>().AddAsync(entitySave);
                }
            }
            await UnitOfWork.SaveChangesAsync();
            return entitiesSave;
        }

        public async Task RemoveSaveEntitiesAsync(List<T> entities)
        {
            _writeDbContext.Set<T>().RemoveRange(_writeDbContext.Set<T>().Where(o => entities.Select(o => o.Id).Contains(o.Id)));
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<T> AddOrEditEntityAsync(T entitySave)
        {
            var entityExist = await _writeDbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == entitySave.Id);
            string userName = string.IsNullOrEmpty(_userProvider.UserName) ? "Guest" : _userProvider.UserName;
            if (entityExist != null)
            {
                entitySave.CreatedDateTime = entityExist.CreatedDateTime;
                entitySave.CreatedBy = entityExist.CreatedBy;
                entitySave.UpdatedDateTime = _dateTimeProvider.OffsetNow;
                entitySave.UpdatedBy = userName;
                _writeDbContext.Entry(entityExist).CurrentValues.SetValues(entitySave);
            }
            else
            {
                entitySave.Id = Guid.NewGuid();
                entitySave.CreatedDateTime = _dateTimeProvider.OffsetNow;
                entitySave.CreatedBy = userName;
                entitySave.UpdatedDateTime = null;
                entitySave.UpdatedBy = string.Empty;
                await _writeDbContext.Set<T>().AddAsync(entitySave);
            }
            return entitySave;
        }
        public void RemoveEntity(T entity)
        {
            _writeDbContext.Set<T>().Remove(entity);
        }
        public void RemoveEntities(List<T> entities)
        {
            _writeDbContext.Set<T>().RemoveRange(_writeDbContext.Set<T>().Where(o => entities.Select(o => o.Id).Contains(o.Id)));
        }
        public async Task CloseEntity(T entity)
        {
            string userName = string.IsNullOrEmpty(_userProvider.UserName) ? "Guest" : _userProvider.UserName;
            var entityExist = await _writeDbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == entity.Id);
            if (entityExist != null)
            {
                entityExist.UpdatedDateTime = _dateTimeProvider.OffsetNow;
                entityExist.UpdatedBy = userName;
            }
        }
    }
}
