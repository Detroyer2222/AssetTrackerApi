using DeleteOrganization;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Delete;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Delete("organization");
        Summary(s =>
        {
            s.Description = "Delete an organization";
        });
        Policies("Owner");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new Commands.DeleteOrganization()
        {
            OrganizationId = r.OrganizationId
        }.ExecuteAsync(c);

        await SendAsync(new Response { IsSuccess = result });
    }
}