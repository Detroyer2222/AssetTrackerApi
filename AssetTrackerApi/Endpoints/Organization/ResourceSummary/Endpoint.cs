using AssetTrackerApi.Endpoints.Organization.ResourceSummary.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.ResourceSummary;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("/api/organization/resources");
        Roles("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new GetOrganizationResources
        {
            OrganizationId = r.OrganizationId
        }.ExecuteAsync(c);

        await SendAsync(new Response { Resources = result });
    }
}