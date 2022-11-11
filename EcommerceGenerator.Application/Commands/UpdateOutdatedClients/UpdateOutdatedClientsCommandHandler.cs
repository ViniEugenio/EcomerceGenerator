using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UpdateOutdatedClientsCommand
{
    public class UpdateOutdatedClientsCommandHandler : IRequestHandler<UpdateOutdatedClientsCommand, ResponseViewModel>
    {

        private readonly IClientRepository ClientRepository;

        public UpdateOutdatedClientsCommandHandler(IClientRepository ClientRepository)
        {
            this.ClientRepository = ClientRepository;
        }

        public async Task<ResponseViewModel> Handle(UpdateOutdatedClientsCommand request, CancellationToken cancellationToken)
        {

            var result = new ResponseViewModel();
            var SomeClientUpdated = await ClientRepository.UpdateOutdatedClients();

            if (!SomeClientUpdated)
            {

                result.AddError(ClientMessages.AllClientsUpdates);
                result.AddMessage(ClientMessages.ErrorUpdatedOutdatedClients);

            }

            else
            {
                result.AddMessage(ClientMessages.SucessUpdatedOutdatedClients);
            }

            return result;

        }

    }
}
