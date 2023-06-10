using FastEndpoints;
using FluentValidation;

namespace DeleteUser
{
    public class Request
    {
        public int UserId { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Response
    {
        public bool IsSuccess { get; set; }
    }
}