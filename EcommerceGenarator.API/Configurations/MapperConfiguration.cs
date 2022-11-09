using AutoMapper;
using EcommerceGenerator.Application.Commands.CreateClientCommand;
using EcommerceGenerator.Application.ViewModels.Client;
using EcommerceGenerator.Domain.Entites.Admin;

namespace EcommerceGenarator.Api.Configurations
{
    public static class MapperConfiguration
    {

        public static void ConfigureMapper(this IServiceCollection services)
        {

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Client, ClientViewModel>();
                cfg.CreateMap<CreateClientCommand, Client>();

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }

    }
}
