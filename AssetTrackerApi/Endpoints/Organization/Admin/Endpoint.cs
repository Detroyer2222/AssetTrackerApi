using AssetTrackerApi.Endpoints.Organization.Admin.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Admin;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/api/organization/admin");
        Summary(s =>
        {
            s.Summary = "Change organization access status of user";
        });
        Roles("Admin", "Owner");
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