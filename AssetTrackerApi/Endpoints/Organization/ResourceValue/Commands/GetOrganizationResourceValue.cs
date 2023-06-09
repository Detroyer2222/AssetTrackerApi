using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.ResourceValue.Commands
{
    public class GetOrganizationResourceValue : ICommand<double>
    {
        public int OrganizationId { get; set; }
    }
}
