using AssetTrackerApi.Endpoints.User.Admin.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Admin;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/organisation/admin");
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