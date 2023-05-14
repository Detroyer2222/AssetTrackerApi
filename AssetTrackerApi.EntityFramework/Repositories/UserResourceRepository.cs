using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class UserResourceRepository : AssetTrackerRepository<UserResource>, IUserResourceRepository
{
    public UserResourceRepository(AssetTrackerContext context) : base(context)
    {
    }
}