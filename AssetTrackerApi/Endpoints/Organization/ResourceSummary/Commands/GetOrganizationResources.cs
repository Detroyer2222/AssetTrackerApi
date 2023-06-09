using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.ResourceSummary.Commands;

public class GetOrganizationResources : ICommand<List<OrganizationResourceDto>>
{
    public int OrganizationId { get; set; }
}