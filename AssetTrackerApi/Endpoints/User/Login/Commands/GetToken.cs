using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Login.Commands;

public class GetToken : ICommand<string>
{
    public string EmailorUserName { get; set; }
    public int? OrganisationId { get; set; }
}