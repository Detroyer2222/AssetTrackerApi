using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.User.AddBalance;

public class Request
{
    public int UserId { get; set; }
    public long Balance { get; set; }
    public bool IsAdded { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Balance).NotEmpty();
        RuleFor(x => x.IsAdded).NotEmpty();
    }
}

public class Response
{
    public long Balance { get; set; }
}