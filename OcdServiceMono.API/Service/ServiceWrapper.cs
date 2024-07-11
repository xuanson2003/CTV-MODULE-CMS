using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;



namespace OcdServiceMono.API.Service
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly ReadDomainDbContext _readContext;
        private readonly WriteDomainDbContext _writeContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;

        public ServiceWrapper(ReadDomainDbContext readContext, WriteDomainDbContext writeContext, IDateTimeProvider dateTimeProvider, IUserProvider userProvider)
        {
            _readContext = readContext;
            _writeContext = writeContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userProvider;
        }
        private CMS.Post.IService _CMS_Post = null;
        public CMS.Post.IService CMS_Post => _CMS_Post ?? (_CMS_Post = new CMS.Post.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));

        private SM.Menu.IService _SM_Menu = null;
        public SM.Menu.IService SM_Menu => _SM_Menu ?? (_SM_Menu = new SM.Menu.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));

        private SM.Permission.IService _SM_Permission = null;
        public SM.Permission.IService SM_Permission => _SM_Permission ?? (_SM_Permission = new SM.Permission.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));

        private SM.Role.IService _SM_Role = null;
        public SM.Role.IService SM_Role => _SM_Role ?? (_SM_Role = new SM.Role.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));

        private SM.Department.IService _SM_Department = null;
        public SM.Department.IService SM_Department => _SM_Department ?? (_SM_Department = new SM.Department.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));


        private SM.Accounts.IService _SM_Accounts = null;
        public SM.Accounts.IService SM_Accounts => _SM_Accounts ?? (_SM_Accounts = new SM.Accounts.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));


        private SM.File.IService _SM_File = null;
        public SM.File.IService SM_File => _SM_File ?? (_SM_File = new SM.File.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));

        private CMS.Group_News.IService _CMS_Group_News = null;
        public CMS.Group_News.IService CMS_Group_News => _CMS_Group_News ?? (_CMS_Group_News = new CMS.Group_News.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));

        private CMS.CerContent.IService _CMS_CerContent = null;
        public CMS.CerContent.IService CMS_Cer_Content => _CMS_CerContent ?? (_CMS_CerContent = new CMS.CerContent.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));

        //private CMS.Group_Posts.IService _CMS_Group_Posts = null;
        //public CMS.Group_Posts.IService CMS_Group_Posts => _CMS_Group_Posts ?? (_CMS_Group_Posts = new CMS.Group_Posts.Service(_readContext, _writeContext, _dateTimeProvider, _userProvider));
    }
}
