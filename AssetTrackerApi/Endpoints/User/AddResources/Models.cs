using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.User.AddResources;

public class Request
{
    public int UserId { get; set; }
    public IEnumerable<ResourceToAddDto> ResourcesToAdd { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ResourcesToAdd).NotEmpty();
    }
}

public class Response
{
    public bool IsSuccess { get; set; }
}
