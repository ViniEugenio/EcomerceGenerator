using EcommerceGenarator.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ApiConfigure();
builder.Services.ContextConfigure(builder.Configuration);
builder.Services.ConfigureDenpencies();
builder.Services.IdentityConfigure();
builder.Services.ConfigureMapper();
builder.Services.ConfigureMediator();
builder.Services.ConfigureFilters();
builder.Services.ConfigureFluentValidation();

var app = builder.Build();

app.ApiConfigureBuild();

app.Run();
