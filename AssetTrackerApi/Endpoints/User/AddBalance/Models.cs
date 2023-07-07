using AssetTrackerApi.EntityFramework.Models.Dto.Balance;
using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.User.AddBalance;

public class Request
{
    public int UserId { get; set; }
    public long Balance { get; set; }
    public OperationType OperationType { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Balance).NotEmpty();
        RuleFor(x => x.OperationType).NotEmpty();
    }
}

public class Response
{
    public long Balance { get; set; }
}