using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.User.Admin
{
    public class Request
    {
        public int UserId { get; set; }
        public int OrganisationId { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.OrganisationId).NotEmpty();
        }
    }

    public class Response
    {
        public bool Success { get; set; }
    }
}