﻿using AssetTrackerApi.Endpoints.User.Signup.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.User.Signup;

[EnableCors]
public class Endpoint : Endpoint<Request, Response, Mapper>
{

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