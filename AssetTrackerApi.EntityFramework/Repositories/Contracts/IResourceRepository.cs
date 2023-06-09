using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IResourceRepository: IAssetTrackerRepository<Resource>
{
    Task<Resource> GetResourceByName(string name);
    Task<Resource> GetResourceByCode(string code);
}