using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.User.GetOrganizations;

public class Request
{
    public int UserId { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}

public class Response
{
    public List<EntityFramework.Models.Organization> Organizations { get; set; }
}