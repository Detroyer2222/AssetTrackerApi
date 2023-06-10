using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.GetBalance.Commands;

public class GetOrganizationBalanceHandler : CommandHandler<GetOrganizationBalance, long>
{
    private readonly IOrganizationRepository _organizationRepository;

    public GetOrganizationBalanceHandler(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public override async Task<long> ExecuteAsync(GetOrganizationBalance command, CancellationToken ct = new CancellationToken())
    {
        var result = await _organizationRepository.GetOrganizationBalanceAsync(command.OrganizationId, ct);

        return result;
    }
}