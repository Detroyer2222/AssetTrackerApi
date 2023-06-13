using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.User.GetResources;

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
    public List<ResourceDto> Resources { get; set; }
}