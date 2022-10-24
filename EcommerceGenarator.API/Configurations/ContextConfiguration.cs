using EcommerceGenerator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceGenarator.Api.Configurations
{
    public static class ContextConfiguration
    {

        public static void ContextConfigure(this IServiceCollection services, ConfigurationManager Configuration)
        {

            services.AddDbContext<AdminContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MainConnection"));
            });

            services.AddDbContext<MainContext>();

        }

    }
}
