using DigitalOcean.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalOcean.Infrastructure
{
    public class DigitalOceanContext : DbContext
    {
        public DigitalOceanContext(DbContextOptions<DigitalOceanContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}