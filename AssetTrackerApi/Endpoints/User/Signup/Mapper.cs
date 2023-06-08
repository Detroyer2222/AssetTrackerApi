using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Signup
{
    public class Mapper : Mapper<Request, Response, object>
    {
        public override AssetTrackerApi.EntityFramework.Models.User ToEntity(Request r) => new()
        {
            Email = r.Email,
            UserName = r.UserName,
            SignUpDate = DateTime.UtcNow,
            LastLogin = DateTime.UtcNow,
        };
    }
}