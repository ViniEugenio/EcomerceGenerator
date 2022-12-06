using EcommerceGenerator.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EcommerceGenerator.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

        Task<IdentityResult> CreateUser(User model);
        Task<User> GetUserByIdentifier(string Identifier);
        Task<bool> LoginUser(User FoundedUser, string Password, bool IsPersistence);
        Task<IdentityResult> AddUserClaims(User ActualUser, List<Claim> Claims)

    }
}
