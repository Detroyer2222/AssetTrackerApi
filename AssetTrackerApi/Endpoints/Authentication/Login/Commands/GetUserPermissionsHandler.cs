using System.Security.Claims;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Authentication.Login.Commands;

public class GetUserPermissionsHandler : CommandHandler<GetUserPermissions, KeyValuePair<int, Action<UserPrivileges>>>
{
    private IUserRepository _userRepository;
    private readonly IUserOrganisationRepository _userOrganisationRepository;
    private IOrganizationRepository _organizationRepository;

    public GetUserPermissionsHandler(IUserRepository userRepository, IOrganizationRepository organizationRepository, IUserOrganisationRepository userOrganisationRepository)
    {
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _userOrganisationRepository = userOrganisationRepository;
    }

    public override async Task<KeyValuePair<int, Action<UserPrivileges>>> ExecuteAsync(GetUserPermissions command, CancellationToken ct)
    {
        EntityFramework.Models.User? user;
        if (string.IsNullOrEmpty(command.Email))
        {
            user = await _userRepository.GetByIdAsync(command.UserId, ct);
        }
        else
        {
            user = await _userRepository.GetUserByEmailAsync(command.Email, ct);
        }
        EntityFramework.Models.Organization organisation = null;
        bool isAdmin = false;
        bool isOwner = false;

        if (command.OrganisationId is not (null or 0))
        {
            organisation = await _organizationRepository.GetByIdAsync((int)command.OrganisationId, ct);
            isAdmin = await _userOrganisationRepository.IsUserAdminInOrganizationAsync(user.UserId, (int)command.OrganisationId, ct);
            isOwner = await _userOrganisationRepository.IsUserOwnerInOrganizationAsync(user.UserId, (int)command.OrganisationId, ct);
        }

        ThrowIfAnyErrors();

        return new KeyValuePair<int, Action<UserPrivileges>>(user.UserId, userPrivileges =>
        {
            if (isAdmin)
            {
                userPrivileges.Roles.Add("Admin");
            }
            else if (isOwner)
            {
                userPrivileges.Roles.Add("User");
            }

            userPrivileges.Claims.Add(new(ClaimTypes.Name, user.UserName));
            userPrivileges.Claims.Add(new(ClaimTypes.Email, user.Email));
            userPrivileges.Claims.Add(new(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            
            if (organisation != null)
            {
                userPrivileges.Claims.Add(new("OrganizationId", organisation.OrganizationId.ToString()));
                userPrivileges.Claims.Add(new("OrganizationName", organisation.Name));
            }
        });
    }
}