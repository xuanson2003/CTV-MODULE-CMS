using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OcdServiceMono.Lib.Interfaces;
using System;

namespace OcdServiceMono.API.Infrastructure.DbContexts
{
    public class ReadDomainDbContext : DomainDbContext
    {
        protected new readonly IConfiguration _configuration;
        private readonly IDateTimeProvider _dateTimeProvider;
        public ReadDomainDbContext(IConfiguration configuration, IDateTimeProvider dateTimeProvider) : base(configuration, dateTimeProvider)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.OnConfiguring();
            optionsBuilder.UseNpgsql(_configuration["ReadConnectionString"]).UseSnakeCaseNamingConvention();
        }
    }
}
