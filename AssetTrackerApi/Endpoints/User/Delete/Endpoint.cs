using DeleteUser;
using FastEndpoints;
using Microsoft.ApplicationInsights.WindowsServer;

namespace AssetTrackerApi.Endpoints.User.Delete
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Delete("user");
            Policies("User");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var result = await new Commands.DeleteUser
            {
                UserId = r.UserId
            }.ExecuteAsync(c);

            await SendAsync(new Response{IsSuccess = result});
        }
    }
}