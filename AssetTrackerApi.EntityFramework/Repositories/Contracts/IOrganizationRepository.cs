using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IOrganizationRepository : IAssetTrackerRepository<Organization>
{
    Task<Organization> CreateOrganizationWithOwnerAsync(string organisationName, int ownerId);
    Task<UserOrganization> AddUserToOrganizationAsync(int userId, int organizationId, bool isAdmin, CancellationToken c);

    Task<Organization> GetFirstOrganizationFromUserAsync(int userId);
    Task<List<Organization>> GetOrganizationsFromUserAsync(int userId);
    Task<long> GetOrganizationBalanceAsync(int organisationId);
    Task<IEnumerable<Resource>> GetOrganizationResourcesAsync(int organisationId);
    Task<double> GetTotalResourceValueOfOrganizationAsync(int organisationId);
}