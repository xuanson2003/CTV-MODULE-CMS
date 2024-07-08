using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Interfaces
{
    public interface IUserProvider
    {
        bool IsAuthenticated { get; }        
        Guid UserId { get; }
        string UserName { get; }
        string TenantAppCode { get; }
        string TenantId { get; }
        string TenantCode { get; }
        string AppId { get; }
        string AppCode { get; }
    }
}
