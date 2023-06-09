using AssetTrackerApi.Endpoints.User.Login.Commands;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.User.Login;

[EnableCors]
public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/user/login");
        Summary(s =>
        {
            s.Summary = "Endpoint to create new access token";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        //TODO: Continue here https://fast-endpoints.com/docs/security
        bool authenticated = await new AuthenticatePassword()
        {
            EmailorUserName = r.EmailorUserName,
            Password = r.Password
        }.ExecuteAsync(c);


        string token = null;
        if (authenticated)
        {
            token = await new GetToken()
            {
                EmailorUserName = r.EmailorUserName
            }.ExecuteAsync(c);
        }

        await SendAsync(new()
        {
            EmailorUserName = r.EmailorUserName,
            Token = token
        });
    }
}