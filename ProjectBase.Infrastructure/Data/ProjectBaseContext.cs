using Microsoft.EntityFrameworkCore;
using ProjectBase.Core.Entities;
using System.Reflection;

namespace ProjectBase.Infrastructure.Data
{
    public class ProjectBaseContext : DbContext
    {
        public ProjectBaseContext(DbContextOptions<ProjectBaseContext> options)
         : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientContract> ClientContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Client>().HasData(new Client("Company Test", "99.999.999/9999-99", "Miguel", "emaiil@company.com") { Id = 1 });
        }
    }
}
