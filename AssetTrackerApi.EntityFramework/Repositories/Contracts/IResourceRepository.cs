using AssetTrackerApi.EntityFramework.Models;
using System.Threading.Tasks;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IResourceRepository: IAssetTrackerRepository<Resource>
{
    Task<Resource> GetResourceByName(string name);
    Task<Resource> GetResourceByCode(string code);
}