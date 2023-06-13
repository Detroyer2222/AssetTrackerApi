using AssetTrackerApi.Endpoints.Organization.Admin.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Cors;

namespace AssetTrackerApi.Endpoints.Organization.Admin;

// TODO: Investigate if CORS is needed for secured endpoint
[EnableCors]
public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("organization/admin");
        Summary(s =>
        {
            s.Summary = "Change organization access status of user";
        });
        Policies("Admin", "Owner");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new UpdateOrganisationAccess()
        {
            UserId = r.UserId,
            OrganisationId = r.OrganisationId,
            IsAdmin = r.IsAdmin
        }.ExecuteAsync(c);

        await SendAsync(result);
    }
}