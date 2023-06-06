using AssetTrackerApi.Endpoints.PostProcessor;
using AssetTrackerApi.EntityFramework;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.EntityFramework.Repositories;
using AssetTrackerApi.Tools;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFastEndpoints();

// Define SwaggerDocument here
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Asset Tracker Api";
        s.Version = "v1";

    };
});


var keyVaultEndpoint = new Uri(builder.Configuration["VaultKey"]);
var secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());

KeyVaultSecret insightsSecret = secretClient.GetSecret("ApplicationInsightsConnectionString");
var telemetryOptions = new ApplicationInsightsServiceOptions {ConnectionString = insightsSecret.Value};

KeyVaultSecret connString = secretClient.GetSecret("AssetTrackerSQLConnectionString");

// Configure Authentication
// TODO: Add AuthTokenString to KeyVault
builder.Services.AddJWTBearerAuth("SuperLongAndSecureJWTTokenStringThatWillBeReplacedInTheFutureFuckSecurityAndItsAbsurdNeedsOfLoongKeys");

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("Admin", p => p.RequireRole("Role", "Admin"));
    o.AddPolicy("User", p => p.RequireRole("Role", "User"));
});


// Registering services
builder.Services.AddApplicationInsightsTelemetry(telemetryOptions);
builder.Services.AddDbContext<AssetTrackerContext>(o => o.UseSqlServer(connString.Value, b => b.MigrationsAssembly("AssetTrackerApi")));

// Registering Repositories
builder.Services.AddScoped<IOrganisationRepository, OrganisationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IUserResourceRepository, UserResourceRepository>();
builder.Services.AddScoped<IUserOrganisationRepository, UserOrganisationRepository>();

// Registering Tools
builder.Services.AddScoped<TokenUtility, TokenUtility>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Use and Configure FastEndpoints
app.UseFastEndpoints(c =>
{
    c.Endpoints.Configurator = ep =>
    {
        ep.PostProcessors(Order.After, new ErrorLogger());
    };
});

app.UseSwaggerGen();

app.Run();
