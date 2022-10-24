using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<ResponseViewModel>
    {

        public string Name { get; set; }
        public string Host { get; set; }

    }
}
