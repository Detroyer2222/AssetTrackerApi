using AssetTrackerApi.Endpoints.User.Login.Commands;
using FastEndpoints;
using FastEndpoints.Security;

namespace AssetTrackerApi.Endpoints.User.Login;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("user/login");
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

        //string token = null;
        //if (authenticated)
        //{
        //    token = await new GetToken()
        //    {
        //        EmailorUserName = r.EmailorUserName
        //    }.ExecuteAsync(c);
        //}

        await CookieAuth.SignInAsync(u =>
        {
            u.Roles.Add("Admin");
            u.Permissions.AddRange(new[] {"Create_Item", "Delete_Item"});
            u.Claims.Add(new("UserId", "123"));

            u["Email"] = "abcd@def.com";
            u["Department"] = "IT";
        });


        await SendAsync(new()
        {
            EmailorUserName = r.EmailorUserName,
            Token = ""
        });
    }
}