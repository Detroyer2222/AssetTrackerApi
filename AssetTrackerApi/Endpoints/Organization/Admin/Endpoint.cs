using AssetTrackerApi.Endpoints.Organization.Admin.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Admin;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/api/organization/admin");
        Description(b => b
                   .WithGroupName("Organization")
                   .WithDescription("Update the admin status of a user for an organization"));
        Roles("Admin");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new UpdateOrganisationAcces()
        {
            UserId = r.UserId,
            OrganisationId = r.OrganisationId,
            IsAdmin = r.IsAdmin
        }.ExecuteAsync(c);

        await SendAsync(result);
    }
}