using EcommerceGenerator.Domain.Entites.Admin;
using EcommerceGenerator.Infrastructure.Persistence.Maps.AdminMaps;
using Microsoft.EntityFrameworkCore;

namespace EcommerceGenerator.Infrastructure.Persistence
{
    public class AdminContext : DbContext
    {

        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientMap());

        }

    }
}
