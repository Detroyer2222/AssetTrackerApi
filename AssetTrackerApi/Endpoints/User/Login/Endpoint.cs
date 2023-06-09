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

        // TODO: think about cookie auth when API is deployed and has SSL certificate
        //await CookieAuth.SignInAsync(u =>
        //{
        //    u.Roles.Add("Admin");
        //    u.Permissions.AddRange(new[] {"Create_Item", "Delete_Item"});
        //    u.Claims.Add(new("UserId", "123"));

        //    u["Email"] = "abcd@def.com";
        //    u["Department"] = "IT";
        //});


        await SendAsync(new()
        {
            EmailorUserName = r.EmailorUserName,
            Token = token
        });
    }
}