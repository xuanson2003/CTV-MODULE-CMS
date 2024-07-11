using NuGet.Protocol.Core.Types;

namespace OcdServiceMono.API.Service
{
    public interface IServiceWrapper
    {
        CMS.Post.IService CMS_Post { get; }
        SM.Menu.IService SM_Menu { get; }
        SM.Permission.IService SM_Permission { get; }
        SM.Role.IService SM_Role { get; }
        SM.Department.IService SM_Department { get; }
        SM.Accounts.IService SM_Accounts { get; }
        SM.File.IService SM_File { get; }
        CMS.Group_News.IService CMS_Group_News { get; }

        CMS.CerContent.IService CMS_Cer_Content { get; }

        //CMS.Group_Posts.IService CMS_Group_Posts { get; }
    }
}
