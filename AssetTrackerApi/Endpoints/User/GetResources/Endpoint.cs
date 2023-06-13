using AssetTrackerApi.Endpoints.User.GetResources.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetResources;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        
        Get("user/resources");
        Policies("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new GetUserResources
        {
            UserId = r.UserId
        }.ExecuteAsync(c);

        await SendAsync(new Response { Resources = result });
    }
}