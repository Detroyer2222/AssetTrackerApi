using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Delete.Commands;

public class DeleteOrganization : ICommand<bool>
{
    public int OrganizationId { get; set; }
}