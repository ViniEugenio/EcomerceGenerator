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

        public async Task<Client> CreateClient(Client model)
        {

            model.DataBase = $"{model.Name.ToLower().Replace(" ", string.Empty)}Ecommerce";

            var NewClient = await Add(model);
            await UpdateClientDataBase(model.DataBase);

            return NewClient;

        }

        public async Task<string> GetDataBaseClient()
        {

            var FoundedClient = await Db.FirstOrDefaultAsync(client => client.Host == HttpAcessor.HttpContext.Request.Host.ToString());

            if (FoundedClient == null)
            {
                FoundedClient = await Db.FirstOrDefaultAsync(client => client.Host.Contains("localhost"));
            }

            return FoundedClient.DataBase;

        }

        public async Task<bool> UpdatedDatabase(string DataBase)
        {

            var Context = new MainContext(DataBase);
            var PendingMigrations = await Context.Database.GetPendingMigrationsAsync();
            return !PendingMigrations.Any();

        }

        public async Task UpdateClientDataBase(string DataBase)
        {

            var Context = new MainContext(DataBase);
            await Context.Database.MigrateAsync();

        }

        public async Task<bool> UpdateOutdatedClients()
        {

            bool SomeClientUpdate = false;

            var FoundedClients = await GetAll(client => client.Active);
            foreach (var client in FoundedClients)
            {

                if (!await UpdatedDatabase(client.DataBase))
                {

                    await UpdateClientDataBase(client.DataBase);
                    SomeClientUpdate = true;

                }

            }

            return SomeClientUpdate;

        }

        public async Task ChangeStatusClient(Client model)
        {

            if (model != null)
            {

                model.UpdatedDate = DateTime.Now;
                model.Active = !model.Active;

                await Update(model);

            }

        }
    }
}
