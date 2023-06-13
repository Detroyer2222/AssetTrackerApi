using FastEndpoints;
using FastEndpoints.Security;

namespace AssetTrackerApi.Authentication.Refresh;

public class OrganizationTokenRequest : TokenRequest
{
    public int OrganizationId { get; set; }
}

public class Validator : Validator<OrganizationTokenRequest>
{
    public Validator()
    {

    }
}