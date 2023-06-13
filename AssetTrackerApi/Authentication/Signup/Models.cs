using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Authentication.Signup;

public class Request
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

}

public class Validator : Validator<Request>
{
    public Validator()
    {
        // Rules for UserName
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User Name is required");

        // Rules for Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress();

        // Rules for Password
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}


public class Response
{
    public string UserName { get; set; }
    public string Email { get; set; }
}