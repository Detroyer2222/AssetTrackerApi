using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.Tools;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Login.Commands
{
    public class AuthenticatePasswordHandler : CommandHandler<AuthenticatePassword, bool>
    {
        private IUserRepository _userRepository;

        public AuthenticatePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<bool> ExecuteAsync(AuthenticatePassword command, CancellationToken cancellationToken)
        {
            AssetTrackerApi.EntityFramework.Models.User? user = await _userRepository.GetUserByEmailorUserNameAsync(command.EmailorUserName);

            if (user == null)
            {
                AddError(c => c.EmailorUserName, "User Name or Email not found");
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
}
