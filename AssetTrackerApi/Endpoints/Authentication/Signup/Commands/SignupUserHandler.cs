using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.Tools;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Authentication.Signup.Commands;

public class SignupUserHandler : CommandHandler<SignupUser, EntityFramework.Models.User>
{
    private IUserRepository _userRepository;

    public SignupUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<EntityFramework.Models.User> ExecuteAsync(SignupUser command, CancellationToken ct = new CancellationToken())
    {
        bool userExists = await _userRepository.UserExistsAsync(command.UserToSignup.Email, ct);

        if (userExists)
        {
            AddError(r => command.UserToSignup.Email, "Sorry! E-mail is already in use");
        }

        var passwordSaltPair = PasswordUtility.HashPassword(command.Password);

        command.UserToSignup.PasswordHash = passwordSaltPair.Key;
        command.UserToSignup.Salt = passwordSaltPair.Value;

        var result = await _userRepository.AddAsync(command.UserToSignup, ct);
        if (result is null)
        {
            ThrowError("Sorry! Something went wrong while creating the user");
        }

        ThrowIfAnyErrors();
        return result;
    }
}