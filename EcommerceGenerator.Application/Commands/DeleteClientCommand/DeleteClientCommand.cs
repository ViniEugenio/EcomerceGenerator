using EcommerceGenerator.Application.ViewModels;
using MediatR;

namespace EcommerceGenerator.Application.Commands.DeleteClientCommand
{
    public class DeleteClientCommand : IRequest<ResponseViewModel>
    {
        public Guid ClientId { get; set; }
    }
}
