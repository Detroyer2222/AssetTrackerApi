using AssetTrackerApi.EntityFramework.Models;
using FastEndpoints;
using FluentValidation;

namespace AssetTrackerApi.Endpoints.Organization.AddUser
{
    public class Request
    {
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.OrganizationId).NotEmpty();
            RuleFor(x => x.IsAdmin).NotEmpty();
        }
    }

    public class Response
    {
        public UserOrganization UserOrganization { get; set; }
    }
}