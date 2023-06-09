using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.Organization.ResourceSummary;

public class Request
{
    public int OrganizationId { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty();
    }
}

public class Response
{
    public List<OrganizationResourceDto> Resources { get; set; }
}