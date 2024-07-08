using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OcdServiceMono.API.Infrastructure.Authorization;
using OcdServiceMono.API.Service;
using OcdServiceMono.Lib.Helpers;
using OcdServiceMono.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using OcdServiceMono.Lib.Interfaces;
using OcdServiceMono.Lib.Core;

namespace OcdServiceMono.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase<TEntity> : ControllerBase
    {        
        private ServiceDecorator<TEntity> _serviceDecorator;
        private readonly ILogger _logger;
        private readonly IUserProvider _userProvider;
        public ApiControllerBase(IServiceWrapper service, ILogger logger, IUserProvider userProvider)
        {
            _userProvider = userProvider;
            _logger = logger;
            _serviceDecorator = new ServiceDecorator<TEntity>(service);
        }
        #region base actions
        [HttpGet("get-items")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetEntitiesAsync(int page = 1, int pageSize = 10, string searchBy = "", string orderBy = "", string columns = "new { Id, CreatedBy, CreatedDateTime, UpdatedBy, UpdatedDateTime }")
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {                  
                var items = await _serviceDecorator.GetEntitiesAsync(page, pageSize, searchBy, orderBy, columns);                
                return ResponseMessage.Success(items);                               
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpGet("get-item-by/{id}")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _serviceDecorator.GetEntityByIdAsync(id);                
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPost("add-item")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> AddEntityAsync([FromBody] TEntity model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _serviceDecorator.SaveEntityAsync(model);                
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPut("edit-item")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> EditEntityAsync([FromBody] TEntity model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _serviceDecorator.SaveEntityAsync(model);                
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPost("save-items")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SaveEntitiesAsync([FromBody] List<TEntity> model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _serviceDecorator.SaveEntitiesAsync(model);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpDelete("remove-items")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> RemoveEntitiesAsync([FromBody] List<TEntity> model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                await _serviceDecorator.RemoveEntitiesAsync(model);                
                return ResponseMessage.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }
        #endregion
    }
}
