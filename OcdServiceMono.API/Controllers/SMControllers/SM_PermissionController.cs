using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OcdServiceMono.API.Service;
using OcdServiceMono.Lib.Models;
using System.Reflection;
using System.Threading.Tasks;
using System;
using OcdServiceMono.Lib.Interfaces;
using OcdServiceMono.API.Models.Entities.CMS;
using Microsoft.AspNetCore.Authorization;
using OcdServiceMono.API.Models.Entities.SM;

namespace OcdServiceMono.API.Controllers.CMSControllers
{
    public class SM_PermisstionController : ApiControllerBase<SM_Permission>
    {
        private readonly IUserProvider _userProvider;
        private readonly IServiceWrapper _service;
        private readonly ILogger<SM_PermisstionController> _logger;
        public SM_PermisstionController(IServiceWrapper service, ILogger<SM_PermisstionController> logger, IUserProvider userProvider) : base(service, logger, userProvider)
        {
            _service = service;
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet("Get-SM-Permisstion")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSmMenuAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.SM_Permission.GetAllPermisstion();
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost("Add")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateSMPermissionAsync([FromBody] SM_Permission model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _service.SM_Permission.CreatePermission(model);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSMPermissionAsync([FromBody] SM_Permission model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");

            try
            {

                if (model.Id.ToString() == "")
                {
                    return BadRequest("Missing Permission item identifier");
                }

                var updatedItem = await _service.SM_Permission.UpdatePermission(model.Id, model);

                if (updatedItem == null)
                {
                    return ResponseMessage.Error("Permission item not found");
                }

                return ResponseMessage.Success(updatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}
