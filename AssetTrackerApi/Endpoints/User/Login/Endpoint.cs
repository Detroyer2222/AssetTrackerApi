using AssetTrackerApi.Endpoints.User.Login.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Login;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/user/login");
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