using EcommerceGenerator.Domain.Entites;
using EcommerceGenerator.Domain.Interfaces.Repositories;

namespace EcommerceGenerator.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MainContext Context) : base(Context)
        {
        }
    }
}
