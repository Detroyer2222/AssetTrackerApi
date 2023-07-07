using AssetTrackerApi.Endpoints.User.AddBalance;
using AssetTrackerApi.Endpoints.User.ChangeBalance.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.ChangeBalance;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("user/balance");
        Summary(s =>
        {
            s.Summary = "Change the balance of a user";
        });
        Policies("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new ChangeUserBalance
        {
            Balance = r.Balance,
            OperationType = r.OperationType,
            UserId = r.UserId
        }.ExecuteAsync(c);

        await SendAsync(new Response { Balance = result });
    }
}