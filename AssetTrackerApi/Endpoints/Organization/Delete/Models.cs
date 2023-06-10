using FastEndpoints;
using FluentValidation;

namespace DeleteOrganization
{
    public class Request
    {
        public int OrganizationId { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.OrganizationId).NotEmpty();
        }
    }

    public class Response
    {
        public bool IsSuccess { get; set; }
    }
}