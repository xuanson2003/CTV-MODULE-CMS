using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OcdServiceMono.API.Infrastructure;
using OcdServiceMono.API.Models.Message;
using OcdServiceMono.API.Service;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        private readonly IServiceWrapper _service;
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings appSettings;
        private readonly IPublishEndpoint _publishEndpoint;
        public HomeController(IServiceWrapper service, ILogger<HomeController> logger, IUserProvider userService, IConfiguration rootConfiguration)
        {
            appSettings = new AppSettings();
            rootConfiguration.Bind(appSettings);
            _service = service;
            _logger = logger;
            _userProvider = userService;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
        [HttpGet("/health-check")]
        public IActionResult HealthCheck()
        {
            return Content("Ok i'm fine, kin cha na, kin cha na, teng téng teng tèng");
        }
        //[HttpPost("/send-message")]
        //public async Task<IActionResult> SendMessage(string message)
        //{
        //    await _publishEndpoint.Publish(new SimpleMessage { Text = message });
        //    return Ok($"Sent: {message}");
        //}
        //[HttpPost("/send-message-direct")]
        //public async Task<IActionResult> SendMessageDirect(string type, string message)
        //{
        //    await _publishEndpoint.Publish(new SimpleMessage_Direct { Type = type, Text = message });
        //    return Ok($"Sent: {message}");
        //}
    }
}
