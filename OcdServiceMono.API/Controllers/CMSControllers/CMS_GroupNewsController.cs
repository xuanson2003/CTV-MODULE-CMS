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
    public class CMS_GroupNewsController : ApiControllerBase<CMS_Group_News>
    {
        private readonly IUserProvider _userProvider;
        private readonly IServiceWrapper _service;
        private readonly ILogger<CMS_GroupNewsController> _logger;
        public CMS_GroupNewsController(IServiceWrapper service, ILogger<CMS_GroupNewsController> logger, IUserProvider userProvider) : base(service, logger, userProvider)
        {
            _service = service;
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet("get-cms-groupnew")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCMSGroupNewsAsync()
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var items = await _service.CMS_Group_News.GetAllGroupNews();
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
        public async Task<IActionResult> CreateCMSGroupNewAsync([FromBody] CMS_Group_News model)
        {
            _logger.LogInformation($"Start {MethodBase.GetCurrentMethod()?.Name}");
            try
            {
                var item = await _service.CMS_Group_News.CreateGroupNews(model);
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
