using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.ClientCommands.UpdateOutdatedClients
{
    public class UpdateOutdatedClientsCommand : IRequest<ResponseViewModel>
    {
    }
}
