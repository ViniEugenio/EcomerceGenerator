using AutoMapper;
using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using EcommerceGenerator.Application.ViewModels.User;
using EcommerceGenerator.Domain.Interfaces.Repositories;
using MediatR;

namespace EcommerceGenerator.Application.Commands.UserCommands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseViewModel>
    {

        private readonly IMapper Mapper;
        private readonly IUserRepository UserRepository;

        public LoginCommandHandler(IMapper Mapper, IUserRepository UserRepository)
        {

            this.Mapper = Mapper;
            this.UserRepository = UserRepository;

        }

        public async Task<ResponseViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var response = new ResponseViewModel();
            var FoundedUser = await UserRepository.GetUserByIdentifier(request.Identifier);

            if (FoundedUser == null)
            {
                response.AddError(UserMessages.NotFoundUser);
            }

            else
            {

                var LoginResult = await UserRepository.LoginUser(FoundedUser, request.Password, request.IsPersistence);
                if (LoginResult)
                {
                    response.AddData(Mapper.Map<UserViewModel>(FoundedUser));
                }

                else
                {
                    response.AddError(UserMessages.InvalidLogin);
                }

            }

            response.AddMessage(response.IsValid() ? UserMessages.LoginSuccess : UserMessages.LoginError);
            return response;

        }
    }
}
