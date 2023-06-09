using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.Organization.Create;

public class Request
{
    public int UserId { get; set; }
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.OrganizationName).NotEmpty();
        RuleFor(x => x.OrganizationId).NotEmpty();
    }
}

public class Response
{
    public EntityFramework.Models.Organization CreatedOrganization { get; set; }
}