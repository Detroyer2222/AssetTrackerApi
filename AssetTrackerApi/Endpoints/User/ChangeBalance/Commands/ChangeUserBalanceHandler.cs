using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.ChangeBalance.Commands;

public class ChangeUserBalanceHandler : CommandHandler<ChangeUserBalance, long>
{
    private readonly IUserRepository _userRepository;

    public ChangeUserBalanceHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<long> ExecuteAsync(ChangeUserBalance command, CancellationToken ct = new CancellationToken())
    {
        var result = await _userRepository.ChangeBalance(command.UserId, command.Balance, command.OperationType, ct);

        if (result == null)
        {
            ThrowError("User not found");
        }

        return result.Value;
    }
}