using EcommerceGenerator.Domain.Entites.Admin;
using EcommerceGenerator.Domain.Interfaces.Repositories.AdminRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EcommerceGenerator.Infrastructure.Persistence.Repositories.AdminRepositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {

        private readonly IHttpContextAccessor HttpAcessor;

        public ClientRepository(AdminContext Context, IHttpContextAccessor HttpAcessor) : base(Context)
        {
            this.HttpAcessor = HttpAcessor;
        }

        public async Task CreateClient(Client model)
        {

            await Add(model);

            model.DataBase = model.Name.ToUpper().Replace(" ", string.Empty);
            await UpdatedDatabase(model.DataBase);

        }

        public async Task<string> GetDataBaseClient()
        {

            var FoundedClient = await Db.FirstOrDefaultAsync(client => client.Host == HttpAcessor.HttpContext.Request.Host.ToString());

            if (FoundedClient == null)
            {
                FoundedClient = await Db.FirstOrDefaultAsync(client => client.Host.Contains("localhost"));
            }

            return FoundedClient.Host;

        }

        public async Task<bool> UpdatedDatabase(string DataBase)
        {

            var Context = new MainContext(DataBase);
            var PendingMigrations = await Context.Database.GetPendingMigrationsAsync();
            return !PendingMigrations.Any();

        }

        public async Task UpdateOutdatedClients()
        {

            var FoundedClients = await GetAll(client => client.Active);
            foreach (var client in FoundedClients)
            {
                if (!await UpdatedDatabase(client.DataBase))
                {

                    var Context = new MainContext(client.DataBase);
                    await Context.Database.MigrateAsync();

                }
            }

        }

    }
}
