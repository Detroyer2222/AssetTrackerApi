using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.User.Refresh;

[EnableCors]
public class RefreshTokenService : RefreshTokenService<TokenRequest, TokenResponse>
{

    public RefreshTokenService()
    {
        Setup(o =>
        {
            o.TokenSigningKey = "";
            o.AccessTokenValidity = TimeSpan.FromMinutes(10);
            o.RefreshTokenValidity = TimeSpan.FromDays(6);

            o.Endpoint("/api/user/refresh-token", ep =>
            {
                ep.Summary(s => s.Summary = "Endpoint refreshes the access token and creates new refresh token");
            });
        });
    }

    public override Task PersistTokenAsync(TokenResponse response)
    {
        // TODO: Store refresh token in database
        return Task.CompletedTask;
    }

    public override Task RefreshRequestValidationAsync(TokenRequest req)
    {
        // TODO Validate incoming refresh request by checking token and exiry against the previously stored refresh token
        // if token is not valid add validation error using AddError() method.
        // failures are sent to requesting client. if no failures are added,
        // validation passes and new token pair will be created and sent to client

        return Task.CompletedTask;
    }

    public override Task SetRenewalPrivilegesAsync(TokenRequest request, UserPrivileges privileges)
    {
        // TODO: Set privileges for the new token
        // this applied only to renewal/refresh requests
        // received to the refresh endpoint and not the initial jwt creation

        return Task.CompletedTask;
    }
}