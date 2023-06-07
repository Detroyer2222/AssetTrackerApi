using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IOrganisationRepository : IAssetTrackerRepository<Organisation>
{
    Task<Organisation> GetFirstOrganisationFromUserAsync(int userId);
    Task<List<Organisation>> GetOrganisationsFromUserAsync(int userId);
    Task<IEnumerable<Wallet>> GetOrganisationWalletsAsync(int organisationId);
    Task<IEnumerable<Resource>> GetOrganisationResourcesAsync(int organisationId);
    Task<double> GetTotalResourceValueOfOrganisationAsync(int organisationId);

}