using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.AddUser.Commands;

public class AddUserToOrganizationHandler : CommandHandler<AddUserToOrganization, UserOrganization>
{
    private readonly IOrganizationRepository _organizationRepository;

    public AddUserToOrganizationHandler(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public override async Task<UserOrganization> ExecuteAsync(AddUserToOrganization command, CancellationToken ct = new CancellationToken())
    {
        var result = await _organizationRepository.AddUserToOrganizationAsync(command.UserId, command.OrganizationId, command.IsAdmin, ct);

        return result;
    }
}