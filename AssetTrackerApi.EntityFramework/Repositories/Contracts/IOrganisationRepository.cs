using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IOrganisationRepository : IAssetTrackerRepository<Organisation>
{
    Task<Organisation> GetFirstOrganisationFromUserAsync(int userId);
}