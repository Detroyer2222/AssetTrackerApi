using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.AddBalance.Commands
{
    public class AddUserBalanceHandler : CommandHandler<AddUserBalance, long>
    {
        private readonly IUserRepository _userRepository;

        public AddUserBalanceHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<long> ExecuteAsync(AddUserBalance command, CancellationToken ct = new CancellationToken())
        {
            var result = await _userRepository.AddBalance(command.UserId, command.Balance, command.IsAdded, ct);

            if (result == null)
            {
                ThrowError("User not found");
            }

            return result.Value;
        }
    }
}
