using AutoMapper;
using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Application.ViewModels.Client;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UpdateClientCommand
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ResponseViewModel>
    {

        private readonly IMapper Mapper;
        private readonly IClientRepository ClientRepository;

        public UpdateClientCommandHandler(IMapper Mapper, IClientRepository ClientRepository)
        {
            this.Mapper = Mapper;
            this.ClientRepository = ClientRepository;
        }

        public async Task<ResponseViewModel> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {

            ResponseViewModel response = new ResponseViewModel();
            var FoundedClient = await ClientRepository.GetById(request.Id);

            if (FoundedClient == null)
            {

                response.AddError(ClientMessages.NotFoundedClient);
                response.AddMessage(ClientMessages.ErrorDeleteClient);

                return response;

            }

            response = await ValidateClient(request);
            if (response.IsValid())
            {

                FoundedClient.Name = request.Name;
                FoundedClient.Host = request.Host;

                await ClientRepository.Update(FoundedClient);

                response.AddData(Mapper.Map<ClientViewModel>(FoundedClient));
                response.AddMessage(ClientMessages.SuccessUpdateClient);

            }

            return response;

        }

        private async Task<ResponseViewModel> ValidateClient(UpdateClientCommand request)
        {

            ResponseViewModel response = new ResponseViewModel();

            if (await ClientRepository.Exists(client => client.Id != request.Id && client.Name == request.Name))
            {
                response.AddError(ClientMessages.ClientDuplicatedName);
            }

            if (await ClientRepository.Exists(client => client.Id != request.Id && client.Host == request.Host))
            {
                response.AddError(ClientMessages.ClientDuplicatedHost);
            }

            if (!response.IsValid())
            {
                response.AddMessage(ClientMessages.ErrorUpdateClient);
            }

            return response;

        }

    }
}
