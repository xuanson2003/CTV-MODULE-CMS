using OcdServiceMono.Lib.Interfaces;
using OcdServiceMono.Lib.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace OcdServiceMono.API.Service
{
    class ServiceDecorator<TEntity>
    {
        private IRepositoryBase<TEntity> _repositoryBase;
        public ServiceDecorator(IServiceWrapper repository)
        {
            #region config repository
            if (typeof(TEntity) == typeof(Models.Entities.CMS.CMS_Posts))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.CMS_Post;
            }

            if (typeof(TEntity) == typeof(Models.Entities.SM.SM_Menu))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.SM_Menu;
            }

            if (typeof(TEntity) == typeof(Models.Entities.SM.SM_Permission))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.SM_Permission;
            }
            if (typeof(TEntity) == typeof(Models.Entities.SM.SM_Role))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.SM_Role;
            }

            if (typeof(TEntity) == typeof(Models.Entities.SM.SM_Department))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.SM_Department;
            }

            if (typeof(TEntity) == typeof(Models.Entities.SM.SM_Accounts))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.SM_Accounts;
            }

            if (typeof(TEntity) == typeof(Models.Entities.SM.SM_File))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.SM_File;
            }
            if (typeof(TEntity) == typeof(Models.Entities.CMS.CMS_Group_News))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.CMS_Group_News;
            }
            //if (typeof(TEntity) == typeof(Models.Entities.CMS.CMS_Group_Posts))
            //{
            //    _repositoryBase = (IRepositoryBase<TEntity>)repository.CMS_Group_Posts;
            //}

            if (typeof(TEntity) == typeof(Models.Entities.CMS.CMS_Cer_Content))
            {
                _repositoryBase = (IRepositoryBase<TEntity>)repository.CMS_Cer_Content;
            }


            #endregion
            if (_repositoryBase == null)
            {
                throw new Exception("Class ServiceDecorator not configured yet");
            }    
        }

        #region base service
        public async Task<Paged<TEntity>> GetEntitiesAsync(int page, int pageSize, string searchBy = "", string orderBy = "", string columns = "")
        {
            return await _repositoryBase.GetEntitiesAsync(page, pageSize, searchBy, orderBy, columns);
        }

        public async Task<TEntity> GetEntityByIdAsync(Guid id)
        {
            return await _repositoryBase.GetEntityByIdAsync(id);
        }

        public async Task<TEntity> SaveEntityAsync(TEntity entity)
        {
            return await _repositoryBase.SaveEntityAsync(entity);
        }

        public async Task<List<TEntity>> SaveEntitiesAsync(List<TEntity> entities)
        {
            return await _repositoryBase.SaveEntitiesAsync(entities);
        }        

        public async Task RemoveEntitiesAsync(List<TEntity> entities)
        {
            await _repositoryBase.RemoveSaveEntitiesAsync(entities);
        }

        #endregion
    }
}
