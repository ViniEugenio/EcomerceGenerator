using EcommerceGenerator.Application.Validations.Client;
using FluentValidation.AspNetCore;

namespace EcommerceGenarator.Api.Configurations
{
    public static class FluentValidationConfiguration
    {

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {

            services.AddMvc()
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<CreateClientCommandValidation>());

        }

    }
}
