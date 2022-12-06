using AutoMapper;
using EcommerceGenerator.Application.ViewModels.Client;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using MediatR;

namespace EcommerceGenerator.Application.Queries.ClientQueries.GetClientQuery
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientViewModel>
    {

        private readonly IMapper Mapper;
        private readonly IClientRepository ClientRepository;

        public GetClientQueryHandler(IMapper Mapper, IClientRepository ClientRepository)
        {

            this.Mapper = Mapper;
            this.ClientRepository = ClientRepository;

        }

        public async Task<ClientViewModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            return Mapper.Map<ClientViewModel>(await ClientRepository.GetById(request.ClientId));
        }
    }
}
