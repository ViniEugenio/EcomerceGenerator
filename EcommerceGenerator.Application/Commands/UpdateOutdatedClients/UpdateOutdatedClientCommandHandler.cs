using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UpdateOutdatedClientsCommand
{
    public class UpdateOutdatedClientCommandHandler : IRequestHandler<UpdateOutdatedClientsCommand, Unit>
    {

        private readonly IClientRepository ClientRepository;

        public UpdateOutdatedClientCommandHandler(IClientRepository ClientRepository)
        {
            this.ClientRepository = ClientRepository;
        }

        public async Task<Unit> Handle(UpdateOutdatedClientsCommand request, CancellationToken cancellationToken)
        {

            await ClientRepository.UpdateOutdatedClients();
            return Unit.Value;

        }

    }
}
