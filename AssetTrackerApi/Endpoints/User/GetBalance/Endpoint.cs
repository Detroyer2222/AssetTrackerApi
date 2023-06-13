using AssetTrackerApi.Endpoints.User.GetBalance.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetBalance;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("user/balance");
        Summary(s =>
        {
            s.Summary = "Gets a user's Balance";
        });
        Policies("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new GetUserBalance
        {
            UserId = r.UserId
        }.ExecuteAsync(c);

        await SendAsync(new Response { UserBalance = result });
    }
}