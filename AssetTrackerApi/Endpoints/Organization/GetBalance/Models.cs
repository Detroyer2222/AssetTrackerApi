using FastEndpoints;
using FluentValidation;

namespace GetOrganizationBalance
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
        public long OrganizationBalance { get; set; }
    }
}