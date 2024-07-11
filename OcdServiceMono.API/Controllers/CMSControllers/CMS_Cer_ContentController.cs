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

namespace OcdServiceMono.API.Controllers.CMSControllers
{
    public class CMS_Cer_ContentController : ApiControllerBase<CMS_Cer_Content>
    {
        private readonly IUserProvider _userProvider;
        private readonly IServiceWrapper _service;
        private readonly ILogger<CMS_Cer_ContentController> _logger;
        public CMS_Cer_ContentController(IServiceWrapper service, ILogger<CMS_Cer_ContentController> logger, IUserProvider userProvider) : base(service, logger, userProvider)
        {
            _service = service;
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet("get-cms-cer-content")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCMSCerContentAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.CMS_Cer_Content.GetAllCerContent();
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
        public async Task<IActionResult> CreateCMSCerContentAsync([FromBody] CMS_Cer_Content model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _service.CMS_Cer_Content.CreateCerContent(model);
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
