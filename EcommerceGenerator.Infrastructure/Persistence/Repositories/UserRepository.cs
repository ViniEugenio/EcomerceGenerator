using EcommerceGenerator.Domain.Entites;
using EcommerceGenerator.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EcommerceGenerator.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;

        public UserRepository(MainContext Context, UserManager<User> UserManager, SignInManager<User> SignInManager) : base(Context)
        {

            this.UserManager = UserManager;
            this.SignInManager = SignInManager;

        }

        public async Task<IdentityResult> AddUserClaims(User ActualUser, List<Claim> Claims)
        {
            return await UserManager.AddClaimsAsync(ActualUser, Claims);
        }

        public async Task<IdentityResult> CreateUser(User model)
        {
            return await UserManager.CreateAsync(model, model.PasswordHash);
        }

        public async Task<User> GetUserByIdentifier(string Identifier)
        {

            var FoundedUser = await UserManager.FindByEmailAsync(Identifier);

            if (FoundedUser == null)
            {
                FoundedUser = await UserManager.FindByNameAsync(Identifier);
            }

            return FoundedUser;

        }

        public async Task<bool> LoginUser(User FoundedUser, string Password, bool IsPersistence)
        {

            var result = await SignInManager.PasswordSignInAsync(FoundedUser, Password, IsPersistence, false);
            return result.Succeeded;

        }
    }
}
