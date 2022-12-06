using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.ClientCommands.ChangeStatusClientCommand
{
    public class ChangeStatusClientCommand : IRequest<ResponseViewModel>
    {
        public Guid ClientId { get; set; }
    }
}
