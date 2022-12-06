using EcommerceGenerator.Application.ViewModels.Client;
using MediatR;

namespace EcommerceGenerator.Application.Queries.ClientQueries.GetAllClientsQuery
{
    public class GetAllClientsQuery : IRequest<List<ClientViewModel>>
    {
    }
}
