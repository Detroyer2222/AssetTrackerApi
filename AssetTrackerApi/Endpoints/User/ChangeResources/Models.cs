using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.User.ChangeResources;

public class Request
{
    public int UserId { get; set; }
    public IEnumerable<ResourceToChangeDto> ResourcesToChange { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ResourcesToChange).NotEmpty();
    }
}

public class Response
{
    public bool IsSuccess { get; set; }
}
