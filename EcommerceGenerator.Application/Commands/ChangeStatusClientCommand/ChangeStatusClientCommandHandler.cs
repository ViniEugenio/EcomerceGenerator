using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.ChangeStatusClientCommand
{
    public class ChangeStatusClientCommandHandler : IRequestHandler<ChangeStatusClientCommand, ResponseViewModel>
    {

        private readonly IClientRepository ClientRepository;

        public ChangeStatusClientCommandHandler(IClientRepository ClientRepository)
        {
            this.ClientRepository = ClientRepository;
        }

        public async Task<ResponseViewModel> Handle(ChangeStatusClientCommand request, CancellationToken cancellationToken)
        {

            var response = new ResponseViewModel();

            var FoundedClient = await ClientRepository.GetById(request.ClientId);
            if (FoundedClient == null)
            {

                response.AddError(ClientMessages.NotFoundedClient);
                response.AddMessage(ClientMessages.ErrorDeleteClient);

                return response;

            }

            await ClientRepository.ChangeStatusClient(FoundedClient);
            response.AddMessage(ClientMessages.SuccessDeleteClient);

            return response;

        }

    }
}
