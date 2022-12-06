using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.ClientCommands.UpdateOutdatedClient
{
    public class UpdateOutdatedClientCommand : IRequest<ResponseViewModel>
    {
        public Guid ClientId { get; set; }

        public UpdateOutdatedClientCommand(Guid ClientId)
        {
            this.ClientId = ClientId;
        }

    }
}
