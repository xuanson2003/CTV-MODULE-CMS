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
using System.Drawing;
using OcdServiceMono.API.Models.Dtos;

namespace OcdServiceMono.API.Controllers.CMSControllers
{
    public class SM_MenuController : ApiControllerBase<SM_Menu>
    {
        private readonly IUserProvider _userProvider;
        private readonly IServiceWrapper _service;
        private readonly ILogger<SM_MenuController> _logger;
        public SM_MenuController(IServiceWrapper service, ILogger<SM_MenuController> logger, IUserProvider userProvider) : base(service, logger, userProvider)
        {
            _service = service;
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet("get-sm-menu")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSmMenuAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.SM_Menu.GetAllMenu();
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
        public async Task<IActionResult> CreateSmMenuAsync([FromBody] SM_Menu model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _service.SM_Menu.CreateMenu(model);
                return ResponseMessage.Success(item);             
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSmMenuAsync([FromBody] SM_Menu model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");

            try
            {
                // Validate if the model contains an identifier (e.g., Id) for the menu item to update
                if (model.Id.ToString() == "" ) // Modify this check based on your identifier property
                {
                    return BadRequest("Missing menu item identifier");
                }

                var updatedItem = await _service.SM_Menu.UpdateMenu(model.Id ,model);

                if (updatedItem == null)
                {
                    return ResponseMessage.Error("Menu item not found");
                }

                return ResponseMessage.Success(updatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message); // Internal Server Error
            }
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteSmMenuAsync(Guid id)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _service.SM_Menu.DeleteMenu(id);
                if (item == null)
                {
                    return ResponseMessage.Error("Menu not found or already deleted.");
                }
                return ResponseMessage.Success(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }


    }
}
