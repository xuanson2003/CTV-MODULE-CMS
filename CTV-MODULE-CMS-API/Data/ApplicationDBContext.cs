
// entity framework core: to access the database without coding in db
using Microsoft.EntityFrameworkCore;
using CTV_MODULE_CMS_API.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CTV_MODULE_CMS_API.Data
{
    public class ApplicationDbContext : DbContext // provided by Entity Framework Core and represents a session with the database, allowing for querying and saving data.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Articles> Articles { get; set; } // represents a table in the database
    }
}
