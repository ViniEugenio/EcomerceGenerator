using EcommerceGenerator.Application.ViewModels.Client;
using MediatR;

namespace EcommerceGenerator.Application.Queries.GetClientQuery
{
    public class GetClientQuery : IRequest<ClientViewModel>
    {
        public Guid ClientId { get; set; }
    }
}
