using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetResources.Commands;

public class GetUserResources : ICommand<List<ResourceDto>>
{
    public int UserId { get; set; }
}