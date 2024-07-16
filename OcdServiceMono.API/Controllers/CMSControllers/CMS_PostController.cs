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
using Microsoft.AspNetCore.Authorization;
using OcdServiceMono.API.Models.Entities.SM;

namespace OcdServiceMono.API.Controllers.CMSControllers
{
    public class CMS_PostController : ApiControllerBase<CMS_Posts>
    {
        private readonly IUserProvider _userProvider;
        private readonly IServiceWrapper _service;
        private readonly ILogger<CMS_PostController> _logger;
        public CMS_PostController(IServiceWrapper service, ILogger<CMS_PostController> logger, IUserProvider userProvider) : base(service, logger, userProvider)
        {
            _service = service;
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet("Get-Top-Post")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetEntitiesTopPostAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.CMS_Post.GetEntitiesTopPostAsync();
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("Get-News-Post")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetEntitieNewsPostAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.CMS_Post.GetEntitiesNewsPostAsync();
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("Get-CMS-Post")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCMSPostAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.CMS_Post.GetAllPost();
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
        public async Task<IActionResult> CreateCMSPostAsync([FromBody] CMS_Posts model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _service.CMS_Post.CreatePost(model);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{MethodBase.GetCurrentMethod()?.Name} error: {ex.Message}");
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCMSPostAsync([FromBody] CMS_Posts model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");

            try
            {

                if (model.Id.ToString() == "")
                {
                    return BadRequest("Missing Posts item identifier");
                }

                var updatedItem = await _service.CMS_Post.UpdatePost(model.Id, model);

                if (updatedItem == null)
                {
                    return ResponseMessage.Error("Posts item not found");
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
