using EcommerceGenerator.Domain.Entites;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using EcommerceGenerator.Infrastructure.Persistence.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceGenerator.Infrastructure.Persistence
{
    public class MainContext : IdentityDbContext<User>
    {

        private readonly string ConnectionString = $"Server=localhost\\SQLEXPRESS;Database=!!ClientDataBase!!;Trusted_Connection=True;";

        public MainContext(DbContextOptions<MainContext> options, IClientRepository ClientRepository) : base(options)
        {

            try
            {
                ConnectionString = ConnectionString.Replace("!!ClientDataBase!!", ClientRepository.GetDataBaseClient().Result);
            }

            catch { }

        }

        public MainContext(string DataBase)
        {
            ConnectionString = ConnectionString.Replace("!!ClientDataBase!!", DataBase);
        }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ProductMap());

        }

    }
}
