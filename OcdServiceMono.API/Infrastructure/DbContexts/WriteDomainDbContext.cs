using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Threading;
using OcdServiceMono.Lib.Interfaces;

namespace OcdServiceMono.API.Infrastructure.DbContexts
{
    public class WriteDomainDbContext : DomainDbContext, IUnitOfWork
    {
        private IDbContextTransaction _dbContextTransaction;
        protected new readonly IConfiguration _configuration;
        private readonly IDateTimeProvider _dateTimeProvider;
        public WriteDomainDbContext(IConfiguration configuration, IDateTimeProvider dateTimeProvider) : base(configuration, dateTimeProvider)
        {
            _configuration = configuration;
            _dateTimeProvider = dateTimeProvider;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.OnConfiguring();
            optionsBuilder.UseNpgsql(_configuration["WriteConnectionString"]).UseSnakeCaseNamingConvention(); 

        }
        #region IUnitOfWork
        public void CreateTransaction()
        {
            _dbContextTransaction = Database.BeginTransaction();
        }
        public void Commit()
        {
            _dbContextTransaction.Commit();
        }
        public void Roolback()
        {
            _dbContextTransaction.Rollback();
            _dbContextTransaction.Dispose();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        private void OnBeforeSaveChanges()
        {

        }
        #endregion
    }
}
