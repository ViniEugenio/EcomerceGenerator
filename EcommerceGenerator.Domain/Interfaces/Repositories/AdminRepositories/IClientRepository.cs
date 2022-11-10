using EcommerceGenerator.Domain.Entites.Admin;

namespace EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories
{
    public interface IClientRepository : IRepository<Client>
    {

        Task<string> GetDataBaseClient();
        Task<bool> UpdatedDatabase(string DataBase);
        Task UpdateOutdatedClients();
        Task<Client> CreateClient(Client model);
        Task UpdateClientDataBase(string DataBase);
        Task ChangeStatusClient(Client model);

    }
}
