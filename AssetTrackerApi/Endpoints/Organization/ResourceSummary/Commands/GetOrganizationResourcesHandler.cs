using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.ResourceSummary.Commands;

public class GetOrganizationResourcesHandler : CommandHandler<GetOrganizationResources, List<OrganizationResourceDto>>
{
    private readonly IOrganizationRepository _organizationRepository;

    public GetOrganizationResourcesHandler(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    } 

    public override async Task<List<OrganizationResourceDto>> ExecuteAsync(GetOrganizationResources command, CancellationToken ct = new CancellationToken())
    {
        var result = await _organizationRepository.GetOrganisationResourcesSummaryAsync(command.OrganizationId, ct);

        return result;
    }
}