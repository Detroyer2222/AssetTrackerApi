using AssetTrackerApi.EntityFramework;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.EntityFramework.Repositories;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var keyVaultEndpoint = new Uri(builder.Configuration["VaultKey"]);
var secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());

KeyVaultSecret insightsSecret = secretClient.GetSecret("ApplicationInsightsConnectionString");
var telemetryOptions = new ApplicationInsightsServiceOptions {ConnectionString = insightsSecret.Value};

KeyVaultSecret connString = secretClient.GetSecret("AssetTrackerSQLConnectionString");


//Registering services
builder.Services.AddApplicationInsightsTelemetry(telemetryOptions);
builder.Services.AddDbContext<AssetTrackerContext>(o => o.UseSqlServer(connString.Value, b => b.MigrationsAssembly("AssetTrackerApi")));

//Registering Repositories
builder.Services.AddScoped<IOrganisationRepository, OrganisationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IUserResourceRepository, UserResourceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
