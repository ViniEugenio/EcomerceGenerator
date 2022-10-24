using EcommerceGenerator.Domain.Entites;
using EcommerceGenerator.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace EcommerceGenarator.Api.Configurations
{
    public static class IdentityConfiguration
    {

        public static void IdentityConfigure(this IServiceCollection services)
        {

            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<MainContext>()
               .AddDefaultTokenProviders();

        }

    }
}
