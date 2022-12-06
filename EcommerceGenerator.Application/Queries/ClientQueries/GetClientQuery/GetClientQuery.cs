using EcommerceGenerator.Application.ViewModels.Client;
using MediatR;

namespace EcommerceGenerator.Application.Queries.ClientQueries.GetClientQuery
{
    public class GetClientQuery : IRequest<ClientViewModel>
    {
        public Guid ClientId { get; set; }
    }
}
