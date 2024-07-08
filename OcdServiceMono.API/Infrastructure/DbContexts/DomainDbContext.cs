using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using OcdServiceMono.API.Models.Entities.CMS;
using OcdServiceMono.Lib.Common;
using OcdServiceMono.Lib.Core;
using OcdServiceMono.Lib.Helpers;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OcdServiceMono.Lib.Common.Consts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OcdServiceMono.API.Infrastructure.DbContexts
{
    public class DomainDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        private readonly IDateTimeProvider _dateTimeProvider;
        public DomainDbContext(IConfiguration configuration, IDateTimeProvider dateTimeProvider)
        {
            _configuration = configuration;
            _dateTimeProvider = dateTimeProvider;
        }
        public DomainDbContext(DbContextOptions<DomainDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }
        public void OnConfiguring()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //var defaultTenant = new Cia_Tenant { Id = Guid.NewGuid(), Code = DefaultTenant.ToLower(), Name = DefaultTenant, Domain = "", CreatedBy = "admin", CreatedDateTime = _dateTimeProvider.OffsetNow, RecordStatus = RecordStatus.RELEASED };
            //builder.Entity<Cia_Tenant>().HasData(defaultTenant);

            //var defaultApp = new Cia_App { Id = Guid.NewGuid(), Code = DefaultApp.ToLower(), Name = DefaultApp, CreatedBy = "admin", CreatedDateTime = _dateTimeProvider.OffsetNow, RecordStatus = RecordStatus.RELEASED };
            //builder.Entity<Cia_App>().HasData(defaultApp);

            //var defaultTenantApp = new Cia_Tenant_App { Id = Guid.NewGuid(), TenantAppCode = DefaultTenant.ToLower() + "." + DefaultApp.ToLower(), TenantId = defaultTenant.Id, AppId = defaultApp.Id };
            //builder.Entity<Cia_Tenant_App>().HasData(defaultTenantApp);


            //var password = "admin@123";
            //var defaultSalt = SecurityHelper.CreateSalt(128/8);
            //var defaultPasswordHash = SecurityHelper.Encrypt(password, defaultSalt);
            //var defaultUser = new Cia_User
            //{
            //    Id = Guid.NewGuid(),
            //    FullName = "admin",
            //    Gender = null,
            //    ContactEmail = "admin@default.com",
            //    PhoneNumber = "0123456789",
            //    UserName = "admin",
            //    PasswordHash = defaultPasswordHash,
            //    Salt = defaultSalt,
            //    IsActive = true,
            //    IsSuper = true,
            //    Type = Consts.UserType.System,
            //    CreatedBy = "admin",
            //    CreatedDateTime = _dateTimeProvider.OffsetNow,
            //    RecordStatus = RecordStatus.RELEASED
            //};
            //builder.Entity<Cia_User>().HasData(defaultUser);

            base.OnModelCreating(builder);
        }

        #region Dataset
        public DbSet<CMS_Post> CMS_Posts { get; set; }

        #endregion
    }
}
