using AssetTrackerApi.Endpoints.Authentication.Login.Commands;
using AssetTrackerApi.Endpoints.Authentication.Refresh;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.Authentication.Login;

[EnableCors]
public class Endpoint : Endpoint<Request, TokenResponse>
{
    public override void Configure()
    {
        Post("authentication/login");
        Summary(s =>
        {
            s.Summary = "Endpoint to create new access token";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        bool authenticated = await new AuthenticatePassword
        {
            Email = r.Email,
            Password = r.Password
        }.ExecuteAsync(c);

        if (!authenticated)
            ThrowError("Invalid username or password");

        var result = await new GetUserPermissions
        {
            Email = r.Email,
            OrganisationId = r.OrganisationId

        }.ExecuteAsync(c);
        
        Response = await CreateTokenWith<RefreshTokenService>(result.Key.ToString(), result.Value);
    }
}