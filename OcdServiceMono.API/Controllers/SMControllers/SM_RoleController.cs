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
    public class SM_RoleController : ApiControllerBase<SM_Permission>
    {
        private readonly IUserProvider _userProvider;
        private readonly IServiceWrapper _service;
        private readonly ILogger<SM_RoleController> _logger;
        public SM_RoleController(IServiceWrapper service, ILogger<SM_RoleController> logger, IUserProvider userProvider) : base(service, logger, userProvider)
        {
            _service = service;
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet("get-sm-role")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSmMenuAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.SM_Role.GetAllRole();
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRoleAsync([FromBody] SM_Role model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _service.SM_Role.CreateRole(model);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}
