using AutoMapper;
using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Domain.Entites;
using EcommerceGenerator.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EcommerceGenerator.Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseViewModel>
    {

        private readonly IMapper Mapper;
        private readonly IUserRepository UserRepository;

        public CreateUserCommandHandler(IUserRepository UserRepository, IMapper Mapper)
        {

            this.Mapper = Mapper;
            this.UserRepository = UserRepository;

        }

        public async Task<ResponseViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var transaction = await UserRepository.BeginTransaction();

            var response = await ValidateUser(request);

            if (!response.IsValid())
            {
                return response;
            }

            var Result = await UserRepository.CreateUser(Mapper.Map<User>(request));

            if (Result.Succeeded)
            {

                var ActualUser = await UserRepository.GetUserByIdentifier(request.Email);
                Result = await AssignUserClaims(ActualUser);

                if (Result.Succeeded)
                {

                    response.AddMessage(UserMessages.CreateUserSuccess);
                    response.AddData(ActualUser);
                    await UserRepository.CommitTransaction(transaction);

                }

                else
                {

                    response.AddManyErrors(Result.Errors
                        .Select(error => error.Description).ToArray());

                }

            }

            else
            {

                response.AddManyErrors(Result.Errors
                    .Select(error => error.Description).ToArray());

            }

            if (!response.IsValid())
            {

                response.AddMessage(UserMessages.CreateUserError);
                await UserRepository.RollBackTransaction(transaction);

            }

            return response;

        }

        private async Task<ResponseViewModel> ValidateUser(CreateUserCommand request)
        {

            var response = new ResponseViewModel();

            if (await UserRepository.Exists(user => user.Email.Equals(request.Email)))
            {
                response.AddError(UserMessages.DuplicatedUserEmail);
            }

            if (await UserRepository.Exists(user => user.UserName.Equals(request.UserName)))
            {
                response.AddError(UserMessages.DuplicatedUserName);
            }

            if (!response.IsValid())
            {
                response.AddMessage(UserMessages.CreateUserError);
            }

            return response;

        }

        private async Task<IdentityResult> AssignUserClaims(User ActualUser)
        {

            var UserAmount = await UserRepository.CountByExpression(user => user.Active);
            var UserClaims = new List<Claim>
            {
                UserAmount == 1 ? new Claim("Admin", "Admin") : new Claim("Client", "Client")
            };

            return await UserRepository.AddUserClaims(ActualUser, UserClaims);

        }

    }
}
