using Microsoft.AspNetCore.Http;
using OcdServiceMono.Lib.Common;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Core
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context;
        }

        public bool IsAuthenticated
        {
            get
            {
                bool isAuthenticated = false;
                try
                {
                    isAuthenticated = _context.HttpContext.User.Identity.IsAuthenticated;
                }
                catch { }
                return isAuthenticated;
            }
        }

        public Guid UserId
        {
            get
            {
                Guid userId = Guid.Empty;
                try
                {
                    userId = Guid.Parse(_context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                }
                catch { }
                return userId;
            }
        }
        public string UserName
        {
            get
            {
                string userName = string.Empty;
                try
                {
                    userName = _context.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                }
                catch { }
                return userName;
            }
        }
        public string TenantAppCode
        {
            get
            {
                string tenantAppCode = string.Empty;
                try
                {
                    tenantAppCode = _context.HttpContext.User.FindFirst(Consts.ClaimTypes.TenantAppCode)?.Value;
                }
                catch { }
                return tenantAppCode;
            }
        }
        public string TenantId
        {
            get
            {
                string tenantId = string.Empty;
                try
                {
                    tenantId = _context.HttpContext.User.FindFirst(Consts.ClaimTypes.TenantId)?.Value;
                }
                catch { }
                return tenantId;
            }
        }
        public string TenantCode
        {
            get
            {
                string tenantCode = string.Empty;
                try
                {
                    tenantCode = _context.HttpContext.User.FindFirst(Consts.ClaimTypes.TenantCode)?.Value;
                }
                catch { }
                return tenantCode;
            }
        }
        public string AppId
        {
            get
            {
                string appId = string.Empty;
                try
                {
                    appId = _context.HttpContext.User.FindFirst(Consts.ClaimTypes.AppId)?.Value;
                }
                catch { }
                return appId;
            }
        }
        public string AppCode
        {
            get
            {
                string appCode = string.Empty;
                try
                {
                    appCode = _context.HttpContext.User.FindFirst(Consts.ClaimTypes.AppCode)?.Value;
                }
                catch { }
                return appCode;
            }
        }
    }
}
