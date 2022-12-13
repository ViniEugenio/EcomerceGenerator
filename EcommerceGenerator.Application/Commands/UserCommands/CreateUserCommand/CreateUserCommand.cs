using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<ResponseViewModel>
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
