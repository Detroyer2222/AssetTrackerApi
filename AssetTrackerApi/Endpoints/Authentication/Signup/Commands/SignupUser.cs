using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Authentication.Signup.Commands;

public class SignupUser : ICommand<EntityFramework.Models.User>
{
    public EntityFramework.Models.User UserToSignup { get; set; }
    public string Password { get; set; }
}