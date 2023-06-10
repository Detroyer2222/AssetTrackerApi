using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.GetUsers
{
    public class Request
    {
        public int OrganizationId { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    public class Response
    {
        public List<EntityFramework.Models.User> Users { get; set; }
    }
}