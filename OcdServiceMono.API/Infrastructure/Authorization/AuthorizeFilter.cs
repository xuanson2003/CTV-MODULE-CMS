using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using OcdServiceMono.API.Service;

namespace OcdServiceMono.API.Infrastructure.Authorization
{
    public class AuthorizeFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = context.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
 
        }
    }
}
