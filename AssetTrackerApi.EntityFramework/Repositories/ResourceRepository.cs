using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class ResourceRepository : AssetTrackerRepository<Resource>, IResourceRepository
{
    public ResourceRepository(AssetTrackerContext context) : base(context)
    {
    }
}