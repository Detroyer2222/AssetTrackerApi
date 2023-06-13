using AssetTrackerApi.Endpoints.Organization.AddUser.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.AddUser;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("organization/add-user");
        Policies("Admin", "Owner");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new AddUserToOrganization()
        {
            UserId = r.UserId,
            OrganizationId = r.OrganizationId,
            IsAdmin = r.IsAdmin
        }.ExecuteAsync(c);

        await SendAsync(new Response { UserOrganization = result });
    }
}