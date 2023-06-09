using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IOrganizationRepository : IAssetTrackerRepository<Organization>
{
    Task<Organization> CreateOrganizationWithOwnerAsync(string organisationName, int ownerId, CancellationToken ct);
    Task<UserOrganization> AddUserToOrganizationAsync(int userId, int organizationId, bool isAdmin, CancellationToken ct);

    Task<Organization> GetFirstOrganizationFromUserAsync(int userId, CancellationToken ct);
    Task<List<Organization>> GetOrganizationsFromUserAsync(int userId, CancellationToken ct);
    Task<long> GetOrganizationBalanceAsync(int organisationId, CancellationToken ct);
    Task<IEnumerable<Resource>> GetOrganizationResourcesAsync(int organisationId, CancellationToken ct);
    Task<double> GetTotalResourceValueOfOrganizationAsync(int organisationId, CancellationToken ct);
}