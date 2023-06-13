using FastEndpoints;

namespace AssetTrackerApi.Authentication.Login.Commands;

public class GetUserPermissions : ICommand<KeyValuePair<int, Action<UserPrivileges>>>
{
    public string EmailOrUserName { get; set; }
    public int UserId { get; set; }
    public int? OrganisationId { get; set; }
}