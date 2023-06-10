using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.GetBalance.Commands;

public class GetOrganizationBalance : ICommand<long>
{
    public int OrganizationId { get; set; }
}