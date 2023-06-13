using FastEndpoints;

namespace AssetTrackerApi.Authentication.Login.Commands;

public class AuthenticatePassword : ICommand<bool>
{
    public string EmailorUserName { get; set; }
    public string Password { get; set; }
}