using EcommerceGenerator.Application.Commands.UpdateClientCommand;
using EcommerceGenerator.Application.Validations.Messages;
using FluentValidation;

namespace EcommerceGenerator.Application.Validations.Client
{
    public class UpdateClientCommandValidation : AbstractValidator<UpdateClientCommand>
    {

        public UpdateClientCommandValidation()
        {

            RuleFor(client => client.Id)
                 .NotEmpty().WithMessage(ClientMessages.EmptyClientName);

            RuleFor(client => client.Name)
                 .NotEmpty().WithMessage(ClientMessages.EmptyClientName);

            RuleFor(client => client.Host)
                .NotEmpty().WithMessage(ClientMessages.EmptyClientHost);

        }

    }
}
