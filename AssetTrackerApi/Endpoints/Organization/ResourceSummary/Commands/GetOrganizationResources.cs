using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.ResourceSummary.Commands;

public class GetOrganizationResources : ICommand<List<ResourceDto>>
{
    public int OrganizationId { get; set; }
}