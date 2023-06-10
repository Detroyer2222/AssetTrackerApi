using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.GetUsers.Commands
{
    public class GetUsersInOrganization : ICommand<List<EntityFramework.Models.User>>
    {
        public int OrganizationId { get; set; }
    }
}
