using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetBalance.Commands
{
    public class GetUserBalanceHandler : CommandHandler<GetUserBalance, long>
    {
        private readonly IUserRepository _userRepository;

        public GetUserBalanceHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<long> ExecuteAsync(GetUserBalance command, CancellationToken ct = new CancellationToken())
        {
            var result = await _userRepository.GetBalance(command.UserId, ct);

            return result;
        }
    }
}
