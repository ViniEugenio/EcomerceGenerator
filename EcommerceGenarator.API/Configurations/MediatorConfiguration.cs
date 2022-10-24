using EcommerceGenerator.Application.Queries.GetAllClientsQuery;
using MediatR;

namespace EcommerceGenarator.Api.Configurations
{
    public static class MediatorConfiguration
    {

        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllClientsQuery));
        }

    }
}
