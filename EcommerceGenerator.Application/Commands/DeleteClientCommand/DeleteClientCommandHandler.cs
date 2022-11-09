using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.DeleteClientCommand
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, ResponseViewModel>
    {

        private readonly IClientRepository ClientRepository;

        public DeleteClientCommandHandler(IClientRepository ClientRepository)
        {
            this.ClientRepository = ClientRepository;
        }

        public async Task<ResponseViewModel> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {

            var response = new ResponseViewModel();

            var FoundedClient = await ClientRepository.GetById(request.ClientId);
            if (FoundedClient == null)
            {

                response.AddError(ClientMessages.NotFoundedClient);
                response.AddMessage(ClientMessages.ErrorDeleteClient);

                return response;

            }

            await ClientRepository.DeleteClient(FoundedClient);
            response.AddMessage(ClientMessages.SuccessDeleteClient);

            return response;

        }

    }
}
