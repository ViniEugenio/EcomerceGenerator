using EcommerceGenerator.Application.Commands.UserCommands.CreateUserCommand;
using EcommerceGenerator.Application.Validations.Messages;
using FluentValidation;

namespace EcommerceGenerator.Application.Validations.User
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidation()
        {

            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage(UserMessages.EmptyUserName);

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(UserMessages.EmptyUserEmail);

            RuleFor(user => user.UserName)
               .NotEmpty()
               .WithMessage(UserMessages.EmptyIdentifier);

            RuleFor(user => user.Password)
               .NotEmpty()
               .WithMessage(UserMessages.EmptyUserPassword);

        }

    }
}
