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

    }
}
