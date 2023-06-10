using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetOrganizations.Commands
{
    public class GetUserOrganizations : ICommand<List<EntityFramework.Models.Organization>>
    {
        public int UserId { get; set; }
    }
}
