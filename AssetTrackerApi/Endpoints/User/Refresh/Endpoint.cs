using System.Runtime.InteropServices.JavaScript;
using AssetTrackerApi.Endpoints.User.Login.Commands;
using AssetTrackerApi.Endpoints.User.Refresh.Commands;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.User.Refresh;

[EnableCors]
public class RefreshTokenService : RefreshTokenService<OrganizationTokenRequest, TokenResponse>
{

    public RefreshTokenService()
    {
        Setup(o =>
        {
            o.TokenSigningKey = "SuperLongAndSecureJWTTokenStringThatWillBeReplacedInTheFutureFuckSecurityAndItsAbsurdNeedsOfLoongKeys"; // TODO: Save longer key in KeyVault
            o.AccessTokenValidity = TimeSpan.FromMinutes(10);
            o.RefreshTokenValidity = TimeSpan.FromHours(10);

            o.Endpoint("user/refresh-token", ep =>
            {
                ep.Summary(s => s.Summary = "Endpoint refreshes the access token and creates new refresh token");
            });
        });
    }

    /// <summary>
    /// this method will be called whenever a new access/refresh token pair is being generated.
    /// store the tokens and expiry dates however you wish for the purpose of verifying
    /// future refresh requests. 
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public override async Task PersistTokenAsync(TokenResponse response)
    {
        var result = await new SaveRefreshToken
        {
            UserId = Int16.Parse(response.UserId),
            RefreshToken = response.RefreshToken,
            RefreshExpiry = response.RefreshExpiry
        }.ExecuteAsync();

    }

    /// <summary>
    /// validate the incoming refresh request by checking the token and expiry against the
    /// previously stored data. if the token is not valid and a new token pair should
    /// not be created, simply add validation errors using the AddError() method.
    /// the failures you add will be sent to the requesting client. if no failures are added,
    /// validation passes and a new token pair will be created and sent to the client. 
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    public override async Task RefreshRequestValidationAsync(OrganizationTokenRequest req)
    {
        // True means validation is successful
        var result = await new ValidateRefreshToken
        {
            UserId = Int16.Parse(req.UserId),
            RefreshToken = req.RefreshToken
        }.ExecuteAsync();

        // Token is not valid
        if (result)
            AddError("Invalid refresh token");
    }

    /// <summary>
    /// specify the user privileges to be embedded in the jwt when a refresh request is
    /// received and validation has passed. this only applies to renewal/refresh requests
    /// received to the refresh endpoint and not the initial jwt creation.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="privileges"></param>
    /// <returns></returns>
    public override async Task SetRenewalPrivilegesAsync(OrganizationTokenRequest request, UserPrivileges privileges)
    {
        var result = await new GetUserPermissions
        {
            UserId = Int16.Parse(request.UserId),
            OrganisationId = request.OrganizationId

        }.ExecuteAsync();

        result.Value(privileges);
    }
}