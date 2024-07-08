using NuGet.Protocol.Core.Types;

namespace OcdServiceMono.API.Service
{
    public interface IServiceWrapper
    {
        CMS.Post.IService CMS_Post { get; }
    }
}
