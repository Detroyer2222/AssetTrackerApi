using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Create.Commands
{
    public class CreateOrganization : ICommand<EntityFramework.Models.Organization>
    {
        public int UserId { get; set; }
        public string OrganizationName { get; set; }
    }
}
