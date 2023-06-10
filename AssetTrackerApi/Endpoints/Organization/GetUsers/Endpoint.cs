using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.GetUsers;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/organization/users");
        Summary(s =>
        {
            s.Description = "Get all users in an organization";
        });
        Policies("Admin", "Owner");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new Commands.GetUsersInOrganization
        {
            OrganizationId = r.OrganizationId
        }.ExecuteAsync(c);

        await SendAsync(new Response{Users = result});
    }
}