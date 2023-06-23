using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.Tools;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Authentication.Login.Commands;

public class AuthenticatePasswordHandler : CommandHandler<AuthenticatePassword, bool>
{
    private IUserRepository _userRepository;

    public AuthenticatePasswordHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<bool> ExecuteAsync(AuthenticatePassword command, CancellationToken ct)
    {
        EntityFramework.Models.User? user = await _userRepository.GetUserByEmailAsync(command.Email, ct);

        if (user == null)
        {
            AddError(c => c.Email, "User Name or Email not found");
        }

        ThrowIfAnyErrors();

        bool result = PasswordUtility.VerifyPassword(command.Password, user.PasswordHash, user.Salt);

        if (!result)
        {
            AddError(c => c.Password, "Password is incorrect");
        }

        ThrowIfAnyErrors();

        return result;
    }
}