using EcommerceGenerator.Domain.Interfaces.Repositories;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using EcommerceGenerator.Infrastructure.Persistence.Repositories;
using EcommerceGenerator.Infrastructure.Persistence.Repositories.AdminRepositories;

namespace EcommerceGenarator.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {

        public static void ConfigureDenpencies(this IServiceCollection services)
        {

            // Repositories
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }

    }
}
