using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UpdateClientCommand
{
    public class UpdateClientCommand : IRequest<ResponseViewModel>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }

    }
}
