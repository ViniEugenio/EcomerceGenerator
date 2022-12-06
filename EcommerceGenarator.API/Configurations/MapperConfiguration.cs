using AutoMapper;
using EcommerceGenerator.Application.Commands.ClientCommands.CreateClientCommand;
using EcommerceGenerator.Application.Commands.UserCommands.CreateUserCommand;
using EcommerceGenerator.Application.ViewModels.Client;
using EcommerceGenerator.Application.ViewModels.User;
using EcommerceGenerator.Domain.Entites;
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

                cfg.CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(prop => prop.Password));

                cfg.CreateMap<User, UserViewModel>();

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }

    }
}
