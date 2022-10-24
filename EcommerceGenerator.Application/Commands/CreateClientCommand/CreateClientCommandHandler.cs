using AutoMapper;
using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Domain.Entites.Admin;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.CreateClientCommand
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ResponseViewModel>
    {

        private readonly IMapper Mapper;
        private readonly IClientRepository ClientRepository;

        public CreateClientCommandHandler(IMapper Mapper, IClientRepository ClientRepository)
        {

            this.Mapper = Mapper;
            this.ClientRepository = ClientRepository;

        }

        public async Task<ResponseViewModel> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {

            ResponseViewModel response = await ValidateClient(request);

            if (response.IsValid())
            {
                await ClientRepository.CreateClient(Mapper.Map<Client>(request));
                response.AddMessage(ClientMessages.SuccessRegisterClient);
            }

            return response;

        }

        private async Task<ResponseViewModel> ValidateClient(CreateClientCommand request)
        {

            ResponseViewModel response = new ResponseViewModel();

            if (await ClientRepository.Exists(client => client.Name == request.Name))
            {
                response.AddError(ClientMessages.ClientDuplicatedName);
            }

            if (await ClientRepository.Exists(client => client.Host == request.Host))
            {
                response.AddError(ClientMessages.ClientDuplicatedHost);
            }

            if (response.IsValid())
            {
                response.AddMessage(ClientMessages.ErrorRegisteringClient);
            }

            return response;

        }

    }
}
