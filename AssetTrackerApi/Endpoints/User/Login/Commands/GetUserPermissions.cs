using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Login.Commands;

public class GetUserPermissions : ICommand<KeyValuePair<int, Action<UserPrivileges>>>
{
    public string EmailOrUserName { get; set; }
    public int UserId { get; set; }
    public int? OrganisationId { get; set; }
}