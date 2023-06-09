using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.Tools;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Login.Commands;

public class GetTokenHandler : CommandHandler<GetToken, string>
{
    private IUserRepository _userRepository;
    private TokenUtility tokenUtility;
    private IOrganizationRepository _organizationRepository;

    public GetTokenHandler(IUserRepository userRepository, TokenUtility tokenUtility)
    {
        _userRepository = userRepository;
        this.tokenUtility = tokenUtility;
    }

    public override async Task<string> ExecuteAsync(GetToken command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailorUserNameAsync(command.EmailorUserName);
        EntityFramework.Models.Organization organisation = null;

        if (command.OrganisationId != null)
        {
            organisation = await _organizationRepository.GetByIdAsync((int)command.OrganisationId);
        }

        ThrowIfAnyErrors();

        var token = await tokenUtility.CreateToken(user, organisation);

        return token;
    }
}