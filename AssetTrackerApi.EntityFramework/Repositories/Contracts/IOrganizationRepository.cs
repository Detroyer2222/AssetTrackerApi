using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Models.Dto.Resource;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IOrganizationRepository : IAssetTrackerRepository<Organization>
{
    Task<Organization> CreateOrganizationWithOwnerAsync(string organisationName, int ownerId, CancellationToken ct);
    Task<UserOrganization> AddUserToOrganizationAsync(int userId, int organizationId, bool isAdmin, CancellationToken ct);
    Task<bool> RemoveUserFromOrganizationAsync(int userId, int organizationId, CancellationToken ct);
    Task<List<User>> GetUsersInOrganizationAsync(int organizationId, CancellationToken ct);

    Task<Organization> GetFirstOrganizationFromUserAsync(int userId, CancellationToken ct);
    Task<List<Organization>> GetOrganizationsFromUserAsync(int userId, CancellationToken ct);
    Task<long> GetOrganizationBalanceAsync(int organisationId, CancellationToken ct);

    Task<List<ResourceDto>> GetOrganisationResourcesSummaryAsync(int organisationId,
        CancellationToken ct = default(CancellationToken));
    Task<double> GetTotalResourceValueOfOrganizationAsync(int organisationId, CancellationToken ct);
}