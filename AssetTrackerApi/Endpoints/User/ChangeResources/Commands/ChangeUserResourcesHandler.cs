using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.ChangeResources.Commands;

public class ChangeUserResourcesHandler : CommandHandler<ChangeUserResources, bool>
{
    private readonly IUserRepository _userRepository;

    public ChangeUserResourcesHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<bool> ExecuteAsync(ChangeUserResources command, CancellationToken ct = new CancellationToken())
    {
        var result = await _userRepository.ChangeResourcesOfUser(command.UserId, command.ResourcesToAdd, ct);

        if (!result)
        {
            ThrowError($"Error while adding resources to user {command.UserId}");
        }

        return result;
    }
}