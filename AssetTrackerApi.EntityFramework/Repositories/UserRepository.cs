using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class UserRepository : AssetTrackerRepository<User>, IUserRepository
{
    public UserRepository(AssetTrackerContext context) : base(context)
    {
    }
}