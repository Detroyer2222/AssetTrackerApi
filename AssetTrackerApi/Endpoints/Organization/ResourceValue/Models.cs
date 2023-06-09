using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.Organization.ResourceValue;

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
    public double TotalResourceValue { get; set; }
}