using EcommerceGenerator.Domain.Interfaces.Services;
using EcommerceGenerator.Infrastructure.Persistence;
using EcommerceGenerator.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

static ServiceProvider ConfigureServices()
{

    var services = new ServiceCollection();

    services.AddDbContext<AdminContext>(options =>
        options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EcommerceAdmin;Trusted_Connection=True;"));

    services.AddScoped<ITenantService, TenantService>();

    return services.BuildServiceProvider();

}

var serviceProvider = ConfigureServices();

var TenantService = serviceProvider.GetRequiredService<ITenantService>();

var FoundedClients = TenantService.GetAllClients();

Console.WriteLine("---------- Migrations App ----------");
Console.WriteLine();

foreach (var Client in FoundedClients)
{

    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine($"Aplying migrations in {Client.DataBase} database...");
    TenantService.ApplyMigrations(Client.DataBase);
    Console.WriteLine($"Migrations successfully applied in {Client.DataBase} database");

    Console.WriteLine();
    Console.WriteLine();

}

Console.WriteLine();
Console.WriteLine("All databases updated");



