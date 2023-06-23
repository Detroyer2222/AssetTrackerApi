using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.Authentication.Login;

public class Request
{
    public string Email { get; set; }
    public string Password { get; set; }
    public int? OrganisationId { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        // Rules for EmailorUserName
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("User Name or Email is required");

        // Rules for Password
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}

public class Response
{

}