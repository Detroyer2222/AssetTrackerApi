using AssetTrackerApi.Endpoints.User.Signup.Commands;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.User.Signup;

[EnableCors]
public class Endpoint : Endpoint<Request, Response, Mapper>
{
    IUserRepository _userRepository;

    public Endpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override void Configure()
    {
        Post("/api/user/signup");
        Summary(s =>
        {
            s.Summary = "Endpoint to signup new users";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var user = Map.ToEntity(r);


        var result = await new SignupUser
        {
            UserToSignup = user,
            Password = r.Password
        }.ExecuteAsync(c);

        ThrowIfAnyErrors();

        await SendAsync(new()
        {
            UserName = result.UserName,
            Email = result.Email
        });
    }
}