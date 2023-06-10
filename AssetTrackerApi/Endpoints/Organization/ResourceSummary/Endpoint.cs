using AssetTrackerApi.Endpoints.Organization.ResourceSummary.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.Organization.ResourceSummary;

[EnableCors]
public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("/api/organization/resources");
        Policies("User");
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