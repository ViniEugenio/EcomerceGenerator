using EcommerceGenerator.Application.Commands.CreateClientCommand;
using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using FluentValidation;

namespace EcommerceGenerator.Application.Validations.Client
{
    public class CreateClientCommandValidation : AbstractValidator<CreateClientCommand>
    {

        public CreateClientCommandValidation()
        {

            RuleFor(client => client.Name)
                .NotEmpty().WithMessage(ClientMessages.EmptyClientName);

            RuleFor(client => client.Host)
                .NotEmpty().WithMessage(ClientMessages.EmptyClientHost);

        }

    }
}
