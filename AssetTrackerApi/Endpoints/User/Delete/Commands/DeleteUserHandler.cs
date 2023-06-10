using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Delete.Commands
{
    public class DeleteUserHandler : CommandHandler<DeleteUser, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<bool> ExecuteAsync(DeleteUser command, CancellationToken ct = new CancellationToken())
        {
            var result = await _userRepository.DeleteAsync(command.UserId, ct);
            if (!result)
                ThrowError(command => command.UserId, "Error while deleting user");

            return result;
        }
    }
}
