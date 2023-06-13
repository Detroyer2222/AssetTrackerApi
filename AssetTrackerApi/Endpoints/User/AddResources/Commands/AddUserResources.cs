using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.AddResources.Commands
{
    public class AddUserResources : ICommand<bool>
    {
        public int UserId { get; set; }
        public IEnumerable<ResourceToAddDto> ResourcesToAdd { get; set; }
    }
}
