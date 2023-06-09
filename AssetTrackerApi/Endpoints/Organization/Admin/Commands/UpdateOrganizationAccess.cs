using AssetTrackerApi.Endpoints.Organization.Admin;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Admin.Commands;

public class UpdateOrganisationAcces : ICommand<Response>
{
    public int UserId { get; set; }
    public int OrganisationId { get; set; }
    public bool IsAdmin { get; set; }
}