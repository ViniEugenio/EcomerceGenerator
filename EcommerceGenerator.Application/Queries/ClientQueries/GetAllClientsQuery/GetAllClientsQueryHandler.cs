using AutoMapper;
using EcommerceGenerator.Application.ViewModels.Client;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Queries.ClientQueries.GetAllClientsQuery
{
    internal class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientViewModel>>
    {

        private readonly IMapper Mapper;
        private readonly IClientRepository ClientRepository;

        public GetAllClientsQueryHandler(IMapper Mapper, IClientRepository ClientRepository)
        {

            this.Mapper = Mapper;
            this.ClientRepository = ClientRepository;

        }

        public async Task<List<ClientViewModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {

            var FoundedClients = Mapper.Map<List<ClientViewModel>>(await ClientRepository.GetAll());

            if (FoundedClients.Any())
            {

                foreach (var client in FoundedClients)
                {

                    client.UpdatedDatabase = await ClientRepository.UpdatedDatabase(client.DataBase);

                }

            }

            return FoundedClients.OrderByDescending(client => client.CreatedDate).ToList();

        }

    }
}
