using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.AddResources.Commands
{
    public class AddUserResourcesHandler : CommandHandler<AddUserResources, bool>
    {
        private readonly IUserRepository _userRepository;

        public AddUserResourcesHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<bool> ExecuteAsync(AddUserResources command, CancellationToken ct = new CancellationToken())
        {
            var result = await _userRepository.AddResourcesToUser(command.UserId, command.ResourcesToAdd, ct);

            if (!result)
            {
                ThrowError($"Error while adding resources to user {command.UserId}");
            }

            return result;
        }
    }
}
