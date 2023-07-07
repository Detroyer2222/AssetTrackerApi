using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.ChangeResources.Commands;

public class ChangeUserResources : ICommand<bool>
{
    public int UserId { get; set; }
    public IEnumerable<ResourceToChangeDto> ResourcesToAdd { get; set; }
}