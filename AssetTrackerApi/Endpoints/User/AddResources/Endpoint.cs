using AssetTrackerApi.Endpoints.User.AddResources.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.AddResources;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("user/resources");
        Post("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new AddUserResources
        {
            UserId = r.UserId,
            ResourcesToAdd = r.ResourcesToAdd
        }.ExecuteAsync(c);

        await SendAsync(new Response { IsSuccess = result });
    }
}