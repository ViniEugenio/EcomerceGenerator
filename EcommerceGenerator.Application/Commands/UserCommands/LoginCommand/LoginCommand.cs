using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UserCommands.LoginCommand
{
    public class LoginCommand : IRequest<ResponseViewModel>
    {

        public string Identifier { get; set; }
        public string Password { get; set; }
        public bool IsPersistence { get; set; }

    }
}
