using AssetTrackerApi.Endpoints.User.ChangeResources.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.ChangeResources;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("user/resources");
        Policies("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new ChangeUserResources
        {
            UserId = r.UserId,
            ResourcesToAdd = r.ResourcesToAdd
        }.ExecuteAsync(c);

        await SendAsync(new Response { IsSuccess = result });
    }
}