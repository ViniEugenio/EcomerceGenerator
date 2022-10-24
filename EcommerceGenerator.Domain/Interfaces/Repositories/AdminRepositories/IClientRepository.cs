using EcommerceGenerator.Domain.Entites.Admin;

namespace EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<string> GetDataBaseClient();
        Task<bool> UpdatedDatabase(string DataBase);
        Task UpdateOutdatedClients();
        Task CreateClient(Client model);

    }
}
