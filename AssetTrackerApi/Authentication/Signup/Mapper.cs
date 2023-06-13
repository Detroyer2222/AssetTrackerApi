using FastEndpoints;

namespace AssetTrackerApi.Authentication.Signup;

public class Mapper : Mapper<Request, Response, object>
{
    public override EntityFramework.Models.User ToEntity(Request r) => new()
    {
        Email = r.Email,
        UserName = r.UserName,
        SignUpDate = DateTime.UtcNow,
        LastLogin = DateTime.UtcNow,
    };
}