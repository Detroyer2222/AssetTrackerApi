using FastEndpoints;
using FluentValidation;

namespace User.Login
{
    public class Request
    {
        public string EmailorUserName { get; set; }
        public string Password { get; set; }
        public int? OrganisationId { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            // Rules for EmailorUserName
            RuleFor(x => x.EmailorUserName)
                .NotEmpty()
                .WithMessage("User Name or Email is required");

            // Rules for Password
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }

    public class Response
    {
        public string EmailorUserName { get; set; }
        public string Token { get; set; }
    }
}