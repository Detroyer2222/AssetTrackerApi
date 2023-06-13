using AssetTrackerApi.Endpoints.Organization.Create.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Create;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("organization/create");
        Summary(s =>
        {
            s.Summary = "Create new Organization";
        });
        Policies("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new CreateOrganization
        {
            OrganizationName = r.OrganizationName,
            UserId = r.UserId

        }.ExecuteAsync(c);

        await SendAsync(new Response { CreatedOrganization = result });
    }
}