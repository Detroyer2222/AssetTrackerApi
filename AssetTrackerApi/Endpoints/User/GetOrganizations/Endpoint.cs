using AssetTrackerApi.Endpoints.User.GetOrganizations.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.User.GetOrganizations;

[EnableCors]
public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("user/organizations");
        Summary(s =>
        {
            s.Summary = "Endpoint to get all organizations of a user";
        });
        
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new GetUserOrganizations
        {
            UserId = r.UserId
        }.ExecuteAsync(c);

        await SendAsync(new Response { Organizations = result });
    }
}