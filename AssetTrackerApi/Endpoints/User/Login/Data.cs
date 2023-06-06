using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.Tools;
using FastEndpoints;

namespace User.Login
{
    public class Data
    {
    }


    #region CreateToken

    public class GetToken : ICommand<string>
    {
        public string EmailorUserName { get; set; }
        public int? OrganisationId { get; set; }
    }

    public class GetTokenHandler : CommandHandler<GetToken, string>
    {
        private IUserRepository _userRepository;
        private TokenUtility tokenUtility;
        private IOrganisationRepository _organisationRepository;

        public GetTokenHandler(IUserRepository userRepository, TokenUtility tokenUtility)
        {
            _userRepository = userRepository;
            this.tokenUtility = tokenUtility;
        }

        public override async Task<string> ExecuteAsync(GetToken command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailorUserNameAsync(command.EmailorUserName);
            Organisation organisation = null;

            if (command.OrganisationId != null)
            {
                organisation = await _organisationRepository.GetByIdAsync((int)command.OrganisationId);
            }
            
            ThrowIfAnyErrors();

            var token = await tokenUtility.CreateToken(user, organisation);

            return token;
        }
    }

    #endregion

    #region AuthenticatePassword
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
                AddError(c =>c.EmailorUserName , "User Name or Email not found");
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

    public class AuthenticatePassword : ICommand<bool>
    {
        public string EmailorUserName { get; set; }
        public string Password { get; set; }
    }

#endregion
}
