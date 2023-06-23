using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Authentication.Login.Commands;

public class GetUserPermissions : ICommand<KeyValuePair<int, Action<UserPrivileges>>>
{
    public string Email { get; set; }
    public int UserId { get; set; }
    public int? OrganisationId { get; set; }
}