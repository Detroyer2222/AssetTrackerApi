using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Delete.Commands;

public class DeleteOrganizationHandler : CommandHandler<DeleteOrganization, bool>
{
    private readonly IOrganizationRepository _organizationRepository;

    public DeleteOrganizationHandler(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public override async Task<bool> ExecuteAsync(DeleteOrganization command, CancellationToken ct = new CancellationToken())
    {
        var result = await _organizationRepository.DeleteAsync(command.OrganizationId, ct);

        if (!result)
            ThrowError(command => command.OrganizationId, "Error deleting Organization");

        return result;
    }
}