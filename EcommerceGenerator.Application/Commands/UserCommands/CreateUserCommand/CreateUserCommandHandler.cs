using AutoMapper;
using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Application.ViewModels.User;
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

            var response = new ResponseViewModel();

            var Result = await UserRepository.CreateUser(Mapper.Map<User>(request));
            var ActualUser = new User();
            if (Result.Succeeded)
            {

                ActualUser = await UserRepository.GetUserByIdentifier(request.Email);
                Result = await AssignUserClaims(ActualUser);

                if (!Result.Succeeded)
                {
                    response.AddManyErrors(Result.Errors.Select(error => error.Description).ToArray());
                }

            }

            else
            {
                response.AddManyErrors(Result.Errors.Select(error => error.Description).ToArray());
            }


            if (response.IsValid())
            {

                response.AddMessage(UserMessages.CreateUserSuccess);
                response.AddData(Mapper.Map<UserViewModel>(ActualUser));

            }

            else
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
                UserAmount == 0 ? new Claim("Admin", "Admin") : new Claim("Client", "Client")
            };

            return await UserRepository.AddUserClaims(ActualUser, UserClaims);

        }

    }
}
