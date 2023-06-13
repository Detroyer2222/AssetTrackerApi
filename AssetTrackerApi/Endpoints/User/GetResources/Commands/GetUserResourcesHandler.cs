using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetResources.Commands;

public class GetUserResourcesHandler : CommandHandler<GetUserResources, List<ResourceDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUserResourcesHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<List<ResourceDto>> ExecuteAsync(GetUserResources command, CancellationToken ct = new CancellationToken())
    {
        var result = await _userRepository.GetResourcesAsync(command.UserId, ct);

        return result;
    }
}