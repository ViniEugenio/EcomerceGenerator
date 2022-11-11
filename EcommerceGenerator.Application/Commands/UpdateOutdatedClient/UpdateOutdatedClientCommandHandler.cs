using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UpdateOutdatedClient
{
    public class UpdateOutdatedClientCommandHandler : IRequestHandler<UpdateOutdatedClientCommand, ResponseViewModel>
    {

        private readonly IClientRepository ClientRepository;

        public UpdateOutdatedClientCommandHandler(IClientRepository ClientRepository)
        {
            this.ClientRepository = ClientRepository;
        }

        public async Task<ResponseViewModel> Handle(UpdateOutdatedClientCommand request, CancellationToken cancellationToken)
        {

            var response = new ResponseViewModel();
            var FoundedClient = await ClientRepository.GetById(request.ClientId);

            if (FoundedClient == null)
            {
                response.AddError(ClientMessages.NotFoundedClient);
            }

            else if (await ClientRepository.UpdatedDatabase(FoundedClient.DataBase))
            {
                response.AddError(ClientMessages.DatabaseUpdated);
            }

            if (response.IsValid())
            {

                await ClientRepository.UpdateClientDataBase(FoundedClient.DataBase);
                response.AddMessage(ClientMessages.SuccessUpdatedOutdatedClient);

            }

            else
            {
                response.AddMessage(ClientMessages.ErrorUpdateOutdatedClient);
            }

            return response;

        }

    }
}
