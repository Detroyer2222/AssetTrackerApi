using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IResourceRepository: IAssetTrackerRepository<Resource>
{
    Task<Resource> GetResourceByName(string name, CancellationToken ct);
    Task<Resource> GetResourceByCode(string code, CancellationToken ct);
}