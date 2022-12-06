using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.ClientCommands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<ResponseViewModel>
    {

        public string Name { get; set; }
        public string Host { get; set; }

    }
}
