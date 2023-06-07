using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class UserResourceRepository : AssetTrackerRepository<UserResource>, IUserResourceRepository
{
    public UserResourceRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<double> GetTotalResourceValueOfUserAsync(int userId)
    {
        return await _context.UserResources
            .Where(ur => ur.UserId == userId)
            .SumAsync(ur => ur.Resource.PriceSell * ur.Quantity);
    }
}