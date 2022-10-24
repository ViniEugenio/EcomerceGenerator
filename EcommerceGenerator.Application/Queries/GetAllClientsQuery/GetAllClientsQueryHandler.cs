using AutoMapper;
using EcommerceGenerator.Application.ViewModels.Client;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Queries.GetAllClientsQuery
{
    internal class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientListViewModel>>
    {

        private readonly IMapper Mapper;
        private readonly IClientRepository ClientRepository;

        public GetAllClientsQueryHandler(IMapper Mapper, IClientRepository ClientRepository)
        {

            this.Mapper = Mapper;
            this.ClientRepository = ClientRepository;

        }

        public async Task<List<ClientListViewModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {

            var FoundedClients = Mapper.Map<List<ClientListViewModel>>(await ClientRepository.GetAll(client => client.Active));

            if (FoundedClients.Any())
            {

                foreach (var client in FoundedClients)
                {

                    client.UpdatedDatabase = await ClientRepository.UpdatedDatabase(client.DataBase);

                }

            }

            return FoundedClients;

        }

    }
}
